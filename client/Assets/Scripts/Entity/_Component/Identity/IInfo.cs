namespace Game
{
    public interface IInfo
    {
        int ConfigId { get; set; }
        string DisplayName { get; set; }
    }

    public interface IHaveInfo
    {
        IInfo Info { get; }
    }
}