using System;
using FastGameDev.Core;
using UnityEngine;
using Object = UnityEngine.Object;

namespace FastGameDev.Entity
{
    public class WorldModel: ComponentBase
        , IGetModule
    {
        private static GameObject kDefaultRoot = new GameObject("model_root");
        
        public GameObject Go { get; private set; }

        public Transform Transform => Go.transform;
        
        public string name = string.Empty;

        public event Action Evt_OnSpawn;
        
        public void Load(Transform parent = null)
        {
            var template = this.Module().Asset.LoadSync<GameObject>(name);

            parent = parent ? parent : kDefaultRoot.transform;
            
            if (template)
            {
                Go = Object.Instantiate(template, parent);
            }
            else
            {
                Go = new GameObject(name);
                Go.transform.SetParent(parent);
            }
            
            Go.name = name;
            
            Evt_OnSpawn?.Invoke();
        }
        
    }
}