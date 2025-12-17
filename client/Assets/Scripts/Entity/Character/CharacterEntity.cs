using FastGameDev;
using FastGameDev.Entity;

namespace Game
{
    public abstract class CharacterEntity : MonoEntityBase
    {
        protected override string Tag =>　"Character";
        public Attributes Attribute { get; private set; } = new Attributes();
        public CharacterInfo Info { get; private set; } = new CharacterInfo();
        public CharacterSetup Setup { get; private set; } = new CharacterSetup();
        //public ItemPacket ItemPacket { get;  private set; } =  new ItemPacket();
    }
}