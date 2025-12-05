using System.Collections.Generic;

namespace FastGameDev.ObjectPool
{
    public class ObjectPool<T> : IObjectPool<T> where T : class, IObject<T>, new()
    {
        private readonly Queue<T> mPool = new ();
        private readonly HashSet<T> mCached = new ();
        
        public T Require()
        {
            if (mPool.Count <= 0)
            {
                var newObj = new T();
                newObj.OnNew();
                mPool.Enqueue(newObj);
            }
            var obj = mPool.Dequeue();
            obj.IsCollected = false;
            obj.OnRequire();
            mCached.Add(obj);
            return obj;
        }

        public void Recycle(T obj)
        {
            if (obj.IsCollected) return;
            obj.IsCollected = true;
            obj.OnRecycle();
            mPool.Enqueue(obj);
            mCached.Remove(obj);
        }

        public void Recycle(IEnumerable<T> objs)
        {
            foreach (var obj in objs) Recycle(obj);
        }

        public void ClearCache()
        {
            foreach (var obj in mCached)
            {
                obj.IsCollected = true;
                obj.OnRecycle();
                mPool.Enqueue(obj);
            }
            mCached.Clear();
            
        }
        
        public void Clear()
        {
            ClearCache();
            mPool.Clear();
        }
    }
}