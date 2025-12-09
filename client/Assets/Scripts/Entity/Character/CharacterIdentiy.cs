namespace Game
{
    public class CharacterIdentiy: IIdentity
    {
        public int Race { get; }

        public CharacterIdentiy(int race)
        {
            Race = race;
        }
    }
}