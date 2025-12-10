using FastGameDev;
using FastGameDev.Entity;

namespace Game
{
    public abstract class CharacterEntity : MonoEntityBase
        , IHaveAttribute
        , IHaveIdentity
        , IHaveInfo
        , IHaveItemPacket
    
    {
        protected override string Tag =>　"Character";
        public abstract IAttribute Attribute { get; protected set; }
        public abstract IIdentity Identity { get;  protected set; }
        public abstract IInfo Info { get;  protected set; }
        public abstract IItemPacket ItemPacket { get;  protected set; }
    }
}