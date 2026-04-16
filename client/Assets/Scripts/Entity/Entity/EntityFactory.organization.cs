using System.Linq;
using GameDev.Entity;
using GameDev.Helper;

namespace Game
{
    public static partial class EntityFactory
    {
        public static Entity RequireSquad()
        {
            var squad = game.Entity.Require<Entity>();
            var attri = squad.Add<Attribute>();
            var res = squad.Add<Resources>();
            var info = squad.Add<SquadInfo>();
            var setup = squad.Add<SquadSetup>();
            var ctx = squad.Add<SquadContext>();
            var model = squad.Add<WorldModel>();
            var selfModel = squad.Add<SquadModel>();
            
            model.name = "squad";
            model.TryLoad();
            
            return squad;
        }

        public static Entity RequireTroop(int troopId)
        {
            var troop = game.Entity.Require<Entity>();
            var info = troop.Add<TroopInfo>();
            var setup = troop.Add<TroopSetup>();
            var ctx = troop.Add<TroopContext>();
            var cfg = game.Tables.TbCampaign.GetOrDefault(troopId);
            
            foreach (var (squadName, squadStances) in cfg.Squads)
            {
                var squad = RequireSquad();
                var squadInfo = squad.Get<SquadInfo>();
                var squadSetup = squad.Get<SquadSetup>();
                var squadAttri = squad.Add<Attribute>();
                var index = 1;
                
                squadInfo.name = squadName;
                squadSetup.troopBelong = troop;
                
                foreach (var stance in squadStances)
                {
                    var character = stance.Id / 10000 == 1 
                        ? RequireAdventurer(stance.Id) 
                        : stance.Id % 60000 > 5000
                            ? RequireEnemy(stance.Id)
                            : RequireAlly(stance.Id);
                    var charSetUp = character.Get<CharacterSetup>();

                    charSetUp.index = index++;
                    charSetUp.squadBelong = squad;
                    charSetUp.squadPos = new SquadPos(stance.Row, stance.Column);
                    
                    squadInfo.stand = stance.Id % 60000 > 5000 ? EmSquadStand.Enemy : EmSquadStand.Ally;
                    if(!squadSetup.Set(stance.Row, stance.Column, character))
                    {
                        Logger.LogWarning($"error '{character.Get<CharacterInfo>().name}' from '{squadInfo.name}' at {stance.Row}th, {stance.Column}th.");
                    }
                }

                squadAttri.Add(PanelAttri.INITIATIVE, squadSetup.characters.Values.Sum(x => ((EntityBase)x).Get<Attribute>()[PanelAttri.INITIATIVE])/ squadSetup.characters.Count);
                
                setup.squads.Add(squad);
            }

            return troop;
        }
    }
}