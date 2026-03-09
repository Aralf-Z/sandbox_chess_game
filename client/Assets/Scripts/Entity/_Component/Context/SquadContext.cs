using System.Collections.Generic;
using FastGameDev.Core;
using FastGameDev.Entity;
using Game.Config.Character;

namespace Game
{
    public class SquadContext :
        ComponentBase
        , IGetModule
    {
        public GridPoint point;
        public int initiative;
        public readonly Dictionary<(int row, int column), ICharacter> characters = new();
    }
}