using GameDev.Entity;

namespace Game
{
    public class TroopBfCursorEntity: EntityBase
        , IWorldModel
    {
        protected override string Tag => "scene";
        
        protected override void Init(int config)
        {
            Model = AddBuiltInComponent<WorldModel>();
            Model.name = "tip_tile_on_select";
            Model.Load();
        }

        public WorldModel Model { get; private set; }
    }
}