using System.Collections.Generic;

namespace Game
{
    public class SquadGrid: ICharactersGrid
    {
        private Dictionary<GridPoint, CharacterEntity> mCharacters = new Dictionary<GridPoint, CharacterEntity>();
        
        public bool SetCharacter(GridPoint point, CharacterEntity character)
        {
            //todo 
            return false;
        }

        public CharacterEntity this[GridPoint point] => mCharacters.GetValueOrDefault(point, null);
    }
}