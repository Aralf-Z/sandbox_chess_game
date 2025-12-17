using FastGameDev;
using FastGameDev.Core;

namespace Game
{
    public sealed class EnemyEntity: CharacterEntity
    {
        protected override void Init(int configId)
        {
            var cfg = this.Module().Config.Tables.TbPreset[configId];
            var itemPreset = cfg.ItemPreset1;
            
            Info.name = cfg.Name;
            Info.configId = configId;
            Info.subrace = cfg.Subrace;
        }
    }
}