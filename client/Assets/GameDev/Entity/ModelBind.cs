using UnityEngine;

namespace GameDev.Entity
{
    public class ModelBind: MonoBehaviour
    {
        public WorldModel ModelCmp { get; private set; }
        
        internal void Bind(WorldModel modelCmp)
        {
            ModelCmp = modelCmp;
        }
    }
}