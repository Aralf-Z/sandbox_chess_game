using FastGameDev.Core;
using UnityEngine;

namespace FastGameDev.Entity
{
    /// <summary>
    /// 需要绑定游戏对象的实体脚本基类
    /// </summary>
    public abstract class MonoEntityBase: MonoBehaviour
        , IGetEntity
        , IGetModule
    {
        protected internal abstract string Tag { get; }
        protected internal abstract void Init(int configId);
    }
}