using GameDev.Core;
using GameDev.Module;

namespace GameDev.Core
{
    public interface IGetModule
    {
        
    }

    public static class GetModuleExtenstion
    {
        public static GameModule Module(this IGetModule getModule)
        {
            return GameApplication.Instance.gameModule;
        }
    }
}