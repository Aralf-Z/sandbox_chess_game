using FastGameDev.Core;
using FastGameDev.Module;

namespace FastGameDev.Core
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