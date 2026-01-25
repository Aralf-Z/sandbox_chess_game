using FastGameDev.Core;
using FastGameDev.Entity;

namespace Game
{
    public class TroopEntity: EntityBase
    {
        protected override string Tag =>　"troop";
        
        protected override void Init(int config)
        {
            Info = AddBuiltInComponent<TroopInfo>();
            Setup = AddBuiltInComponent<TroopSetup>();
            Context = AddBuiltInComponent<TroopContext>();
            
            if(config == 0) return;
            
            var entity = this.Entity();
            var tables = this.Module().Config.Tables;
            
            foreach (var (squadName, squadStances) in tables.TbCampaign[config].Squads)
            {
                var squad = entity.Require<SquadEntity>();
                
                squad.Info.name = squadName;
                squad.Setup.belong = this;
                
                foreach (var stance in squadStances)
                {
                    ICharacter character = stance.Id / 10000 == 1 
                        ? entity.Require<AdventurerEntity>(stance.Id) 
                        : stance.Id % 60000 > 5000
                            ? entity.Require<EnemyEntity>(stance.Id)
                            : entity.Require<AllyEntity>(stance.Id);
                    
                    squad.Setup.Set(stance.Row, stance.Column, character);
                }
                
                Setup.squads.Add(squad);
            }
        }

        public TroopInfo Info { get; private set; }
        public TroopSetup Setup { get; private set; }
        public TroopContext Context { get; private set; }
    }
}