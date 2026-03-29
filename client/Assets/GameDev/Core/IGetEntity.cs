namespace GameDev.Core
{
    public interface IGetEntity
    {
        
    }
    
    public static class IGetEntityExtension
    {
        public static GameEntity Entity(this IGetEntity getEntity)
        {
            return GameApplication.Instance.gameEntity;
        }
    }
}