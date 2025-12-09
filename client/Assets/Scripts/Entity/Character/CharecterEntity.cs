using FastGameDev;
using FastGameDev.Entity;
using FastGameDev.Module;

namespace Game
{
    public abstract class CharecterEntity : MonoEntityBase
        , IHaveAttribute
        , IHaveIdentity
        , IHaveInfo
        , IHaveItemPacket
        , IGetConfig
    {
        protected ConfigModule cfgModule;
        
        public abstract IAttribute Attribute { get; protected set; }
        public abstract IIdentity Identity { get;  protected set; }
        public abstract IInfo Info { get;  protected set; }
        public abstract IItemPacket ItemPacket { get;  protected set; }
    }
}