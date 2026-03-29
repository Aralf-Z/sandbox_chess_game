using GameDev.Entity;
using UnityEngine;

namespace Game
{
    public class SquadModel: ComponentBase
    {
        public WorldModel Model { get; private set; }
        
        protected override void OnAdded()
        {
            Model = Host.Get<WorldModel>();
            Model.Evt_OnLoaded += OnModelLoaded;
        }

        private void OnModelLoaded()
        {
            var render = Model.Transform.GetComponentInChildren<SpriteRenderer>();
            render.sortingOrder = SpriteOrderDefine.TROOP_BATTLEFIELD_SQUAD;
        }
    }
}