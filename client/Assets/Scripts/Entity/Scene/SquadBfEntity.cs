using FastGameDev.Entity;
using UnityEngine;

namespace Game
{
    public class SquadBfEntity: EntityBase
        , IWorldModel
    {
        protected override string Tag => "squad_battlefield";
        
        protected override void Init(int config)
        {
            SelfModel = AddBuiltInComponent<SquadBfModel>();
            Model.name = Tag;
            Model.Load();
            Model.Transform.position = new Vector3(100, 100, 0);
        }


        public WorldModel Model => SelfModel;
        public SquadBfModel SelfModel { get; private set;}
    }
}