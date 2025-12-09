namespace Game
{
    public interface IInfo
    {
        int ConfigId { get; }
        string DisplayName { get; }
    }

    public interface IHaveInfo
    {
        IInfo Info { get; }
    }
}