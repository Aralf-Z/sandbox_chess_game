using Game.Config.Character;
using GameDev.Entity;

namespace Game
{
    public class CharacterInfo: ComponentBase
    {
        public int configId;
        public Asset asset;
        public int subrace;
        public string name;
    }
}