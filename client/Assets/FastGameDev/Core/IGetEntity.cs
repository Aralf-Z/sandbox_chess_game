namespace FastGameDev.Core
{
    public interface IGetEntity
    {
        
    }
    
    internal static class IGetEntityExtension
    {
        public static GameEntity Entity(this IGetEntity getEntity)
        {
            return GameApplication.Instance.gameEntity;
        }
    }
}