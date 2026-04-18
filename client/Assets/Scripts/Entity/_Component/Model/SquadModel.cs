using System.Collections.Generic;
using GameDev.Core;
using GameDev.Entity;
using UnityEngine;

namespace Game
{
    public class SquadModel: ComponentBase
    , IGetModule
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

        public void SetIn(CharacterInfo info, CharacterSetup setup)
        {
            var prefab = this.Module().Asset.LoadSync<GameObject>(info.asset.SquadPrefab);
            Object.Instantiate(prefab, mPoints[setup.index - 1]);
        }

        public void SetOut(Entity member)
        {
            var setup = member.Get<CharacterSetup>();
            //todo 
        }
    }
}