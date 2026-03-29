using GameDev.Entity;

namespace Game
{
    public class SquadEntity: EntityBase
        , IWorldModel
    {
        protected override string Tag =>　"squad";
        
        protected override void Init(int config)
        {
            Attribute = Add<Attribute>();
            Info = Add<SquadInfo>();
            Setup = Add<SquadSetup>();
            Context = Add<SquadContext>();
            Model = Add<WorldModel>();
            SelfModel = Add<SquadModel>();
        }
        
        public Attribute Attribute { get; private set; }
        public SquadInfo Info { get; private set; }
        public SquadSetup Setup { get; private set; }
        public SquadContext Context { get; private set; }
        public SquadModel SelfModel { get; private set; }
        public WorldModel Model { get; private set; }
    }
}