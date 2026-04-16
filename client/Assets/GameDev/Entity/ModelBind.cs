using System;
using GameDev.Core;
using UnityEngine;

namespace GameDev.Entity
{
    public class ModelBind: MonoBehaviour
        , IGetEntity
    {
        public WorldModel ModelCmp { get; private set; }
        
        internal void Bind(WorldModel modelCmp)
        {
            ModelCmp = modelCmp;
        }

        private void OnDestroy()
        {
            this.Entity().Recycle(ModelCmp.Host);
        }
    }
}