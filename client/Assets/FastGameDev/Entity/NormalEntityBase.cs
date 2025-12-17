using FastGameDev.Core;

namespace FastGameDev.Entity
{
    /// <summary>
    /// 不需要绑定游戏对象的实体脚本基类
    /// </summary>
    public abstract class NormalEntityBase :
        IGetEntity
        , IGetModule
    {
        // internal NormalEntityBase()
        // {
        // }

        protected internal abstract string Tag { get; }
        protected internal abstract void Init(int configId);
    }
}