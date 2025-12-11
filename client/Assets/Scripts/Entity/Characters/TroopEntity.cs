using FastGameDev.Core;
using FastGameDev.Entity;

namespace Game
{
    public sealed class TroopEntity: NormalEntityBase
        , IHaveSquads
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
                var squad = entity.RequireNormalEntity<SquadEntity>();
                
                squad.Info.DisplayName = squadName;

                foreach (var stance in squadStances)
                {
                    CharacterEntity ally = stance.Id / 10000 == 1 ? entity.RequireMonoEntity<AdventurerEntity>("adventurer") : entity.RequireMonoEntity<AllyEntity>("ally");
                    squad.SquadGrid.SetCharacter(new GridPoint(stance.Row, stance.Column), ally);
                }
                
                Squads.AllSquads.Add(squad);
            }
        }

        protected override void OnUpdate(float dt)
        {
            
        }

        protected override void OnFixedUpdate(float fdt)
        {
            
        }

        public ISquads Squads { get; } = new TroopSquads();
    }
}