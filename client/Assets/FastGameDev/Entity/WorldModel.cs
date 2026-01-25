using FastGameDev.Core;
using UnityEngine;

namespace FastGameDev.Entity
{
    public class WorldModel: ComponentBase
        , IGetModule
    {
        public GameObject Go { get; private set; }

        public Transform Transform => Go.transform;
        
        public string name = string.Empty;
        
        public void Load(Transform parent = null)
        {
            var template = this.Module().Asset.LoadSync<GameObject>(name);

            if (template)
            {
                Go = Object.Instantiate(template, parent);
            }
            else
            {
                Go = new GameObject(name);
                Go.transform.SetParent(parent);
            }
            
            OnSpawn();
        }

        protected virtual void OnSpawn() { }
    }
}