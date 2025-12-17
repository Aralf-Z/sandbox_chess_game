using FastGameDev.Core;
using FastGameDev.Entity;

namespace Game
{
    public sealed class TroopEntity: NormalEntityBase
    {
        protected override string Tag =>　"Troop";
        
        protected override void Init(int configId)
        {
            if(configId == 0) return;
            
            var entity = this.Entity();
            var tables = this.Module().Config.Tables;
            
            //todo 这里都要整合到Logic??
            //todo temp code
            foreach (var (squadName, squadStances) in tables.TbCampaign[configId].Squads)
            {
                var squad = entity.RequireMonoEntity<SquadEntity>("squad");
                
                squad.Info.name = squadName;

                foreach (var stance in squadStances)
                {
                    CharacterEntity ally = stance.Id / 10000 == 1 
                        ? entity.RequireMonoEntity<AdventurerEntity>("adventurer", stance.Id) 
                        : entity.RequireMonoEntity<AllyEntity>("ally", stance.Id);
                    squad.Setup.characters.Add(ally);
                    squad.Context.SetCharacter(stance.Row, stance.Column, ally);
                }
                
                squad.Refresh();
                Setup.squads.Add(squad);
            }
        }

        public TroopsInfo Info { get; private set; } = new TroopsInfo();
        public TroopsSetup Setup { get; private set; } = new TroopsSetup();
        public TroopsContext Context { get; private set; } = new TroopsContext();
    }
}