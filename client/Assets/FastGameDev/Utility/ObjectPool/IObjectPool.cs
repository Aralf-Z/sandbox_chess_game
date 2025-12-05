using System.Collections.Generic;

namespace FastGameDev.ObjectPool
{
    /// <summary>
    /// 对象池接口
    /// </summary>
    /// <typeparam name="T">对象</typeparam>
    public interface IObjectPool<T> where T : IObject<T>
    {
        T Require();
    
        void Recycle(T obj);
        
        void Recycle(IEnumerable<T> objs);
        
        void ClearCache();
        
        void Clear();
    }
}