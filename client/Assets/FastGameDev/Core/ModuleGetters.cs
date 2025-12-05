using FastGameDev.Core;
using FastGameDev.Module;

namespace FastGameDev
{
    public interface IGetAsset: IGetModule
    {
        
    }

    internal static class IGetAssetExtension
    {
        public static AssetModule Asset(this IGetAsset getAsset)
        {
            return getAsset.Module().Asset;
        }
    }
    
    public interface IGetUI: IGetModule
    {
        
    }

    internal static class IGetUIExtension
    {
        public static UIModule UI(this IGetUI getUI)
        {
            return getUI.Module().UI;
        }
    }
}