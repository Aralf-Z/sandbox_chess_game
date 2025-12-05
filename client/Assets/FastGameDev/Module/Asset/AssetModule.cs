using System.IO;
using FastGameDev.Helper;
using UnityEngine;

namespace FastGameDev.Module
{
    public class AssetModule: MonoBehaviour,
        IModule
    {
        int IModule.InitOrder => InitOrderDefine.ASSET;

        void IModule.Init()
        {
            var file = File.ReadAllText(MapFilePath);
            mAssetMap = JsonHelper.DeserializeObject<AssetMap>(file);
        }

        void IModule.Deinit()
        {
            mAssetMap = null;
        }
        
        public static readonly string MapFilePath = Path.Combine(Application.streamingAssetsPath, "asset_map.json");
        
        private AssetMap mAssetMap;
        
        public T LoadSync<T>(string assetName) where T : Object
        {
            return Resources.Load<T>(mAssetMap[assetName]);
        }
    }
}