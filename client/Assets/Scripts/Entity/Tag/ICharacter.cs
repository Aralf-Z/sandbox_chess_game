using GameDev.Entity;

namespace Game
{
    public interface ICharacter: IWorldModel
    {
        CharacterInfo Info { get; }
    }
}