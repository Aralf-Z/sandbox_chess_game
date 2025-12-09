namespace FastGameDev.Core
{
    public interface IGetLogic
    {
        
    }

    public static class IGetLogicExtension
    {
        public static GameLogic GetLogic(this IGetLogic getLogic)
        {
            return GameApplication.Instance.gameLogic;
        }
    }
}