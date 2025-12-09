namespace FastGameDev.Core
{
    public interface IGetRecord
    {
        
    }

    public static class IGetRecordExtension
    {
        public static GameRecord Data(this IGetRecord getMemory)
        {
            return GameApplication.Instance.gameRecord;
        }
    }
}