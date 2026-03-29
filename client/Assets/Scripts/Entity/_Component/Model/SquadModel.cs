using GameDev.Entity;
using UnityEngine;

namespace Game
{
    public class SquadModel: ComponentBase
    {
        public WorldModel Model { get; private set; }

        protected override void OnHostReady()
        {
            var render = Model.Transform.GetComponentInChildren<SpriteRenderer>();
            render.sortingOrder = SpriteOrderDefine.TROOP_BATTLEFIELD_SQUAD;
        }
    }
}