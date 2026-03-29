using System;
using GameDev.Core;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameDev.Entity
{
    public class WorldModel: ComponentBase
        , IGetModule
        , IGetEntity
    {
        public GameObject Go { get; private set; }

        public ModelBind Bind { get; private set; }
        
        public Transform Transform => Go.transform;
        
        public string name = string.Empty;

        public event Action Evt_OnLoaded;

        public void Load()
        {
            var template = this.Module().Asset.LoadSync<GameObject>(name);
            var parent = this.Entity().transform;
            
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
            Bind = Go.AddComponent<ModelBind>();
            Bind.Bind(this);
            Evt_OnLoaded?.Invoke();
        }
    }
}