using FastGameDev;
using FastGameDev.Core;

namespace Game
{
    public sealed class AdventurerEntity: CharacterEntity
    {
        protected override void OnUpdate(float dt)
        {
            
        }

        protected override void OnFixedUpdate(float fdt)
        {
            
        }

        public override IAttribute Attribute { get; protected set; }
        public override IIdentity Identity { get; protected set; }
        public override IInfo Info { get; protected set; }
        public override IItemPacket ItemPacket { get; protected set; }
        
        protected override void Init(int configId)
        {
            //todo 后面并非预设，能自定义
            var cfg = this.Module().Config.Tables.TbAdventurer[configId];
            var itemPreset = cfg.ItemPreset1;
            
            Attribute = new CharacterAttri();
            Identity = new CharacterIdentiy(cfg.Subrace);
            Info = new CharacterInfo(cfg.Id, cfg.Name);
            ItemPacket = new CharacterItemPacket(itemPreset.MainHand, itemPreset.OffHand, itemPreset.Body, itemPreset.Artifacts);
        }
    }
}