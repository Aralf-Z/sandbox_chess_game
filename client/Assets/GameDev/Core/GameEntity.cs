using System.Collections;
using System.Collections.Generic;
using GameDev.Entity;
using GameDev.Helper;
using UnityEngine;

namespace GameDev.Core
{
    //todo 先暂时把逻辑写在Entity中吧？ Logic的分离，感觉有点设计过度的样子
    public class GameEntity : MonoBehaviour,
        IGetModule
    {
        private readonly HashSet<EntityBase> mEntities = new HashSet<EntityBase>();
        
        internal void Init()
        {

        }

        internal void Destroy()
        {
            
        }
        
        public T Require<T>() where T : EntityBase, new ()
        {
            var en = new T();
            mEntities.Add(en);
            return en;
        }

        public void Recycle<T>(T entity) where T : EntityBase
        {
            entity.Clear();
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