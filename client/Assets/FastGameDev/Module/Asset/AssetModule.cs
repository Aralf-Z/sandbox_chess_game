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
            var file = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, MAP_FILE_NAME));
            mAssetMap = JsonHelper.DeserializeObject<AssetMap>(file);
        }

        void IModule.Deinit()
        {
            mAssetMap = null;
        }
        
        void IModule.OnUpdate(float dt)
        {
            
        }
        
        public const string MAP_FILE_NAME = "asset_map.json";

        private AssetMap mAssetMap;
        
        public T LoadSync<T>(string assetName) where T : Object
        {
            return Resources.Load<T>(mAssetMap[assetName]);
        }
    }
}