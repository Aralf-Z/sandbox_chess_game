using Game.Config;
using GameDev.Core;
using GameDev.Entity;

namespace Game
{
    public static partial class EntityFactory
    {
        private class Game : IGetEntity, IGetModule
        {
            public GameEntity Entity => this.Entity();
            public Tables Tables => this.Module().Config.Tables;
        }

        private static readonly Game game = new Game();

        public static Entity RequireAdventurer(int configId)
        {
            var ad = game.Entity.Require<Entity>();
            var attri = ad.Add<Attribute>();
            var info = ad.Add<CharacterInfo>();
            var setup = ad.Add<CharacterSetup>();
            var model = ad.Add<WorldModel>();
            var cfg = game.Tables.TbAdventurer[configId];
            var preset = cfg.ItemPreset1;

            info.name = cfg.Name;
            info.configId = configId;
            info.subrace = cfg.Subrace;
            
            attri.Add(PanelAttri.INITIATIVE, cfg.AttributePreset.Initiative);
            
            model.name = "adventurer";
            model.TryLoad();
            
            return ad;
        }
        
        public static Entity RequireAlly(int configId)
        {
            var ally = game.Entity.Require<Entity>();
            var attri = ally.Add<Attribute>();
            var info = ally.Add<CharacterInfo>();
            var setup = ally.Add<CharacterSetup>();
            var model = ally.Add<WorldModel>();
            var cfg = game.Tables.TbAdventurer[configId];
            var preset = cfg.ItemPreset1;

            info.name = cfg.Name;
            info.configId = configId;
            info.subrace = cfg.Subrace;
            
            attri.Add(PanelAttri.INITIATIVE, cfg.AttributePreset.Initiative);
            
            model.name = "ally";
            model.TryLoad();
            
            return ally;
        }
        
        public static Entity RequireEnemy(int configId)
        {
            var en = game.Entity.Require<Entity>();
            var attri = en.Add<Attribute>();
            var info = en.Add<CharacterInfo>();
            var setup = en.Add<CharacterSetup>();
            var model = en.Add<WorldModel>();
            var cfg = game.Tables.TbAdventurer[configId];
            var preset = cfg.ItemPreset1;

            info.name = cfg.Name;
            info.configId = configId;
            info.subrace = cfg.Subrace;
            
            attri.Add(PanelAttri.INITIATIVE, cfg.AttributePreset.Initiative);
            
            model.name = "enemy";
            model.TryLoad();
            
            return en;
        }
    }
}