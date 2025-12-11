using System.Collections.Generic;
using System.Linq;
using FastGameDev.Module;
using UnityEngine;

namespace FastGameDev.Core
{
    public class GameModule: MonoBehaviour
    {
        internal bool IsInited { get; private set; }
        
        public AssetModule Asset { get; private set; }
        public UIModule UI { get; private set; }
        public ConfigModule Config { get; private set; }
        public CameraModule Camera { get; private set; }
        
        private List<IModule> modules = new();
        
        internal void Init()
        {
            modules = new List<IModule>();
            Asset = GetComponentInChildren<AssetModule>();
            modules.Add(Asset);
            UI = GetComponentInChildren<UIModule>();
            modules.Add(UI);
            Config = GetComponentInChildren<ConfigModule>();
            modules.Add(Config);
            Camera = GetComponentInChildren<CameraModule>();
            modules.Add(Camera);
            
            foreach (var module in modules.OrderBy(m => m.InitOrder))
            {
                module.Init();
            }
        }

        internal void Destroy()
        {
            IsInited = false;
        }
        
        internal void OnUpdate(float dt)
        {
            foreach (var module in modules)
            {
                module.OnUpdate(dt);
            }
        }

        internal void OnFixedUpdate(float dt)
        {
            
        }
    }
}