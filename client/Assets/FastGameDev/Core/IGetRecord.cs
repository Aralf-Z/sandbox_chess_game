namespace FastGameDev.Core
{
    public interface IGetRecord
    {
        
    }

    public static class IGetRecordExtension
    {
        public static GameRecord Record(this IGetRecord getRecord)
        {
            return GameApplication.Instance.gameRecord;
        }
    }
}