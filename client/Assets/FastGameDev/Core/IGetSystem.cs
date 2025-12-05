namespace FastGameDev.Core
{
    public interface IGetSystem
    {
        
    }

    internal static class GetSystemExtension
    {
        public static GameSystem System(this IGetSystem getSystem)
        {
            return GameApplication.Instance.gameSystem;
        }
    }
}