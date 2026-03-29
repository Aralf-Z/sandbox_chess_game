using GameDev.Entity;
using UnityEngine;

namespace Game
{
    public class SquadBfEntity: EntityBase
        , IWorldModel
    {
        protected override string Tag => "squad_battlefield";
        
        protected override void Init(int config)
        {
            Model = Add<WorldModel>();
            SelfModel = Add<SquadBfModel>();
            Model.name = Tag;
            Model.Load();
            Model.Transform.position = new Vector3(100, 100, 0);
        }

        public WorldModel Model { get; private set;}
        public SquadBfModel SelfModel { get; private set;}
    }
}