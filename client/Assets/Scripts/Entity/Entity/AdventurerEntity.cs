using FastGameDev.Core;
using FastGameDev.Entity;

namespace Game
{
    public class AdventurerEntity: EntityBase
        , ICharacter
    {
        public Attribute Attribute { get; private set; }
        public CharacterInfo Info { get; private set; }
        public CharacterSetup Setup { get; private set; }
        public WorldModel Model { get; private set; }
        
        protected override string Tag => "adventurer";
        
        protected override void Init(int config)
        {
            //todo 后面并非预设，能自定义

            Attribute = AddBuiltInComponent<Attribute>();
            Info = AddBuiltInComponent<CharacterInfo>();
            Setup = AddBuiltInComponent<CharacterSetup>();
            Model = AddBuiltInComponent<WorldModel>();
            
            var cfg = this.Module().Config.Tables.TbAdventurer[config];
            var itemPreset = cfg.ItemPreset1;
            
            Info.name = cfg.Name;
            Info.configId = config;
            Info.subrace = cfg.Subrace;
        }
    }
}