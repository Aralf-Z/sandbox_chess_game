using FastGameDev.Entity;

namespace Game
{
    public class SquadEntity: EntityBase
        , IWorldModel
    {
        protected override string Tag =>　"squad";
        
        protected override void Init(int config)
        {
            Attribute = AddBuiltInComponent<Attribute>();
            Info = AddBuiltInComponent<SquadInfo>();
            Setup = AddBuiltInComponent<SquadSetup>();
            Context = AddBuiltInComponent<SquadContext>();
            Model = AddBuiltInComponent<WorldModel>();
        }
        
        public Attribute Attribute { get; private set; }
        public SquadInfo Info { get; private set; }
        public SquadSetup Setup { get; private set; }
        public SquadContext Context { get; private set; }
        public WorldModel Model { get; private set; }
    }
}