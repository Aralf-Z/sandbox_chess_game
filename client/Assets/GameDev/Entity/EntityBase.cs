using System;
using System.Collections.Generic;
using GameDev.Core;
using GameDev.Module;
using Game.Config;

namespace GameDev.Entity
{
    public abstract class EntityBase :
        IGetEntity
        , IGetNote
        , IGetSystem
        , IGetModule
    {
        protected GameNote Note => this.Note();
        protected GameSystem System => this.System();
        protected GameEntity Entity => this.Entity();
        protected AssetModule Asset => this.Module().Asset;
        protected Tables Tables => this.Module().Config.Tables;
        
        internal readonly Dictionary<Type, ComponentBase> mComponents = new();
        
        public IReadOnlyCollection<ComponentBase> Components => mComponents.Values;
        
        protected internal abstract string Tag { get; }

        protected internal abstract void Init(int config);
        
        public T Add<T>() where T: ComponentBase, new()
        {
            var key = typeof(T);
            
            if (mComponents.TryGetValue(key, out var add))
            {
                return (T)add;
            }
            
            var component = new T { Host = this };
            mComponents.Add(key, component);
            component.OnAdded();
            
            return component;
        }
        
        public T Get<T>() where T : ComponentBase
        {
            return (T)mComponents.GetValueOrDefault(typeof(T));
        }

        public T GetOrAdd<T>() where T : ComponentBase, new()
        {
            if (mComponents.TryGetValue(typeof(T), out var tar))
            {
                return (T)tar;
            }
           
            return Add<T>();
        }
        
        public void Remove<T>() where T : ComponentBase
        {
            var key = typeof(T);
            mComponents.Remove(key);
        }

        public bool Has<T>()
        {
            return mComponents.ContainsKey(typeof(T));
        }
    }
}