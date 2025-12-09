using System.Collections.Generic;

namespace Game
{
    public class CharacterAttri: IAttribute
    {
        private readonly Dictionary<EmFixedAttri, float> mFixedAttri;
        private readonly Dictionary<EmResAttri, float> mResourceAttri;
        
        public float this[EmFixedAttri attribute]
        {
            get => mFixedAttri[attribute];
            set => mFixedAttri[attribute] = value;
        }

        public float this[EmResAttri attribute]
        {
            get => mResourceAttri[attribute];
            set => mResourceAttri[attribute] = value;
        }
        
        public static int CalculateModifier(int value) => (value - 10) / 2;
    }
}