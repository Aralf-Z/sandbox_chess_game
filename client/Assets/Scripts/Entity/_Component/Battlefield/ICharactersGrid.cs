namespace Game
{
    //todo 整合到逻辑上
    public interface ICharactersGrid
    {
        CharacterEntity this[GridPoint point] { get; }
        bool SetCharacter(GridPoint point, CharacterEntity character);
    }

    public interface IHaveCharactersGrid
    {
        ICharactersGrid SquadGrid { get; }
    }
}