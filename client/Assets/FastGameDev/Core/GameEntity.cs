using System.Collections;
using System.Collections.Generic;
using FastGameDev.Entity;
using FastGameDev.Helper;
using UnityEngine;

namespace FastGameDev.Core
{
    //todo 先暂时把逻辑写在Entity中吧？ Logic的分离，感觉有点设计过度的样子
    public class GameEntity : MonoBehaviour,
        IGetModule
    {
        private bool mIsInited;
        
        private readonly List<EntityBase> mEntities = new List<EntityBase>();
        
        internal void Init()
        {
            mIsInited = true;
        }

        internal void Destroy()
        {
            mIsInited = false;
        }
        
        public T Require<T>(int configId = -1) where T : EntityBase, new ()
        {
            var en = new T();
            mEntities.Add(en);
            en.Init(configId);
            return en;
        }

        public void Recycle<T>(T entity) where T : EntityBase
        {
            mEntities.Remove(entity);
        }
        
        public void Recycle<T>(IEnumerable<T> entity) where T : EntityBase
        {
            foreach (var e in entity)
            {
                mEntities.Remove(e);
            }
        }
    }
}