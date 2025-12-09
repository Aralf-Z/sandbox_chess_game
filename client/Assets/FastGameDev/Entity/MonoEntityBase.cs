using FastGameDev.Core;
using UnityEngine;

namespace FastGameDev.Entity
{
    public abstract class MonoEntityBase: MonoBehaviour
        , IGetEntity
        , IGetAsset
        , IGetConfig
        , IGetUI
    {
        protected internal abstract void Init(int configId);
        protected internal abstract void OnUpdate(float dt);
        protected internal abstract void OnFixedUpdate(float fdt);
    }
}