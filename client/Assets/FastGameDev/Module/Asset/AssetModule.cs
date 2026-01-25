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
            T asset;
#if UNITY_EDITOR
            var timer = Time.realtimeSinceStartup;

            asset = mAssetMap.Try(assetName, out var path) ? Resources.Load<T>(path) : null;
            
            var cost = Time.realtimeSinceStartup - timer;

            if (cost > .01f)
            {
                LogHelper.Warning($"{assetName} sync cost more than 0.01s [{cost}s], 'LoadAsync' is suggested", "AssetLoad");
            }
#else
            asset = mAssetMap.Try(assetName, out var path) ? Resources.Load<T>(path) : null;
#endif

            return asset;
        }
    }
}