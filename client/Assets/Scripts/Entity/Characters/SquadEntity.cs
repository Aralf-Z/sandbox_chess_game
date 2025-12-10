using FastGameDev.Entity;

namespace Game
{
    public sealed class SquadEntity: NormalEntityBase
        , IHaveInfo
    {
        protected override string Tag =>　"Squad";
        
        protected override void Init(int configId)
        {
            
        }

        protected override void OnUpdate(float dt)
        {
            
        }

        protected override void OnFixedUpdate(float fdt)
        {
            
        }

        public IInfo Info { get; set; }
    }
}