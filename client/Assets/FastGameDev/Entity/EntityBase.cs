using System;
using System.Collections.Generic;
using FastGameDev.Core;
using FastGameDev.Module;
using Game.Config;

namespace FastGameDev.Entity
{
    public abstract class EntityBase :
        IGetEntity
        , IGetRecord
        , IGetSystem
        , IGetModule
    {
        protected GameRecord Record => this.Record();
        protected GameSystem System => this.System();
        protected GameEntity Entity => this.Entity();
        protected AssetModule Asset => this.Module().Asset;
        protected Tables Tables => this.Module().Config.Tables;
        
        private readonly Dictionary<Type, ComponentBase> mBuiltInComponents = new();
        private readonly Dictionary<Type, ComponentBase> mComponents = new();
        
        protected internal abstract string Tag { get; }
        
        protected internal virtual void Init(int config){}

        protected T AddBuiltInComponent<T>() where T: ComponentBase, new()
        {
            var component = Add<T>();
            mBuiltInComponents.Add(typeof(T), component);
            return component;
        }
        
        public T Add<T>() where T: ComponentBase, new()
        {
            var key = typeof(T);
            
            if (mComponents.TryGetValue(key, out var add))
            {
                return (T)add;
            }
            
            var component = new T { Host = this };
            mComponents.Add(key, component);
            return component;
        }
        
        public T Get<T>() where T : ComponentBase
        {
            return (T)mComponents.GetValueOrDefault(typeof(T));
        }
        
        /// <returns> 移出成功 </returns>
        public bool Remove<T>() where T : ComponentBase
        {
            var key = typeof(T);

            if (mBuiltInComponents.ContainsKey(key))
                return false;
            
            var tar = mComponents.GetValueOrDefault(key);
            mComponents.Remove(key);
            mBuiltInComponents.Remove(key);
            return true;
        }

        public bool Has<T>()
        {
            return mComponents.ContainsKey(typeof(T));
        }
        
        public bool IsBuiltin<T>()
        {
            return mBuiltInComponents.ContainsKey(typeof(T));
        }
    }
}