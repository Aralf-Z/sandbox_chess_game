using System.Collections.Generic;

namespace Game
{
    public class SquadAttri: IAttribute
    {
        private readonly Dictionary<EmFixedAttri, float> mFixedAttri = new ();
        private readonly Dictionary<EmResAttri, float> mResourceAttri = new ();
        
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
    }
}