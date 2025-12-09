using FastGameDev.Core;
using FastGameDev.Module;

namespace FastGameDev
{
    public interface IGetAsset: IGetModule
    {
        
    }

    public static class IGetAssetExtension
    {
        public static AssetModule Asset(this IGetAsset getAsset)
        {
            return getAsset.Module().Asset;
        }
    }
    
    public interface IGetUI: IGetModule
    {
        
    }

    public static class IGetUIExtension
    {
        public static UIModule UI(this IGetUI getUI)
        {
            return getUI.Module().UI;
        }
    }
    
    public interface IGetConfig: IGetModule
    {
        
    }

    public static class IGetConfigExtension
    {
        public static ConfigModule UI(this IGetConfig getConfig)
        {
            return getConfig.Module().Config;
        }
    }
}