using System.Collections;
using System.Collections.Generic;
using FastGameDev.Entity;
using UnityEngine;

namespace FastGameDev.Core
{
    public class GameEntity : MonoBehaviour,
        IGetAsset
    {
        private bool mIsInited;
        
        private readonly List<MonoEntityBase> mMonoEntities = new List<MonoEntityBase>();
        
        internal void Init()
        {
            mIsInited = true;
        }

        internal void Destroy()
        {
            mIsInited = false;

            for (var i = mMonoEntities.Count - 1; i >= 0; i--)
            {
                var entity = mMonoEntities[i];
                Destroy(entity.gameObject);
            }
        }
        
        internal void OnUpdate(float dt)
        {
            if (!mIsInited) return;
            
            for (var i = mMonoEntities.Count - 1; i >= 0; i--)
            {
                var entity = mMonoEntities[i];
                entity.OnUpdate(dt);
            }
        }

        internal void OnFixedUpdate(float dt)
        {
            if (!mIsInited) return;
            
            for (var i = mMonoEntities.Count - 1; i >= 0; i--)
            {
                var entity = mMonoEntities[i];
                entity.OnFixedUpdate(dt);
            }
        }

        //todo 未池化
        public T RequireMonoEntity<T>(string assetName, int configId = 0) where T : MonoEntityBase
        {
            var template = this.Asset().LoadSync<GameObject>(assetName);
            var go = Instantiate(template);
            var en = go.GetComponent<T>();
            mMonoEntities.Add(en);
            en.Init(configId);
            return en;
        }

        public void RecycleMonoEntity<T>(T entity) where T : MonoEntityBase
        {
            var go = entity.gameObject;
            mMonoEntities.Remove(entity);
            Destroy(go);
        }
        
        public void RecycleMonoEntity<T>(IEnumerable<T> entity) where T : MonoEntityBase
        {
            foreach (var e in entity)
            {
                var go = e.gameObject;
                mMonoEntities.Remove(e);
                Destroy(go);
            }
        }
    }
}