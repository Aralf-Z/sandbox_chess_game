using FastGameDev;
using FastGameDev.Core;

namespace Game
{
    public sealed class AdventurerEntity: CharacterEntity
    {
        protected override void Init(int configId)
        {
            //todo 后面并非预设，能自定义
            var cfg = this.Module().Config.Tables.TbAdventurer[configId];
            var itemPreset = cfg.ItemPreset1;
            
            Info.name = cfg.Name;
            Info.configId = configId;
            Info.subrace = cfg.Subrace;
        }
    }
}