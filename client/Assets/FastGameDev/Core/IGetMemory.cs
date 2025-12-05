namespace FastGameDev.Core
{
    public interface IGetMemory
    {
        
    }

    internal static class IGetMemoryExtension
    {
        public static GameRecord Data(this IGetMemory getMemory)
        {
            return GameApplication.Instance.gameRecord;
        }
    }
}