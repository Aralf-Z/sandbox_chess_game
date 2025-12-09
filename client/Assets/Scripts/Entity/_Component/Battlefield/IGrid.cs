namespace Game
{
    public interface IGrid
    {
        int this[GridPoint point] {get;}
    }
    
    public interface IHaveGrid
    {
        IGrid Grid { get; }
    }
}