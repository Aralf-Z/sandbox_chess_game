using FastGameDev.Entity;
using UnityEngine;

namespace Game
{
    public class SquadModel: ComponentBase
    {
        public WorldModel Model { get; private set; }
        
        protected override void OnAdded()
        {
            Model = Host.Get<WorldModel>();
            Model.name = "squad";
            Model.Load();
            
            var render = Model.Transform.GetComponentInChildren<SpriteRenderer>();
            render.sortingOrder = SpriteOrderDefine.TROOP_BATTLEFIELD_SQUAD;
        }
    }
}