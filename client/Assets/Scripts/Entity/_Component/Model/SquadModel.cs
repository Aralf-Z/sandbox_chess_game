using System.Collections.Generic;
using GameDev.Entity;
using UnityEngine;

namespace Game
{
    public class SquadModel: ComponentBase
    {
        public WorldModel Model { get; private set; }

        private List<Transform> mPoints = new();
        
        protected override void OnAdded()
        {
            Model = Host.Get<WorldModel>();
            Model.Evt_OnLoaded += OnModelLoaded;
        }

        protected override void OnRemoved()
        {
            Model.Evt_OnLoaded -= OnModelLoaded;
        }
        
        private void OnModelLoaded()
        {
            mPoints.Add(Model.Transform.Find("point1").transform);
            mPoints.Add(Model.Transform.Find("point2").transform);
            mPoints.Add(Model.Transform.Find("point3").transform);
            mPoints.Add(Model.Transform.Find("point4").transform);
            mPoints.Add(Model.Transform.Find("point5").transform);
            mPoints.Add(Model.Transform.Find("point6").transform);
        }

        public void SetIn(Entity member)
        {
            var setup = member.Get<CharacterSetup>();
            var model = member.Get<WorldModel>();
            
            model.Transform.SetParent(mPoints[setup.index - 1]);
            model.Transform.localScale = Vector3.one;
            model.Transform.localPosition = Vector3.zero;
        }

        public void SetOut(Entity member)
        {
            var setup = member.Get<CharacterSetup>();
            //todo 
        }
    }
}