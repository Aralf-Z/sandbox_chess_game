using System;
using System.Collections.Generic;
using System.Linq;
using FastGameDev.Syztem;
using UnityEngine;
using Logger = FastGameDev.Helper.Logger;

namespace FastGameDev.Core
{
    public class GameSystem: MonoBehaviour
    {
        private Dictionary<Type, SystemBase> mSystems = new Dictionary<Type, SystemBase>();
        
        internal bool IsInited { get; private set; }
        
        internal void Init()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var count = 0;

            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes().Where(t => !t.IsAbstract && typeof(SystemBase).IsAssignableFrom(t)))
                {
                    var system = (SystemBase)Activator.CreateInstance(type);
                    system.Init();
                    mSystems.Add(type, system);
                    count++;
                    Logger.LogInfo($"create system '{type.FullName}'", "system");
                }
            }
            
            Logger.LogInfo($"systems loaded '{count}'.", "system");
            
            IsInited = true;
        }

        internal void Destroy()
        {
            IsInited = false;
        }
        
        internal void OnUpdate(float dt)
        {
            
        }

        internal void OnFixedUpdate(float dt)
        {
            
        }

        public T Get<T>() where T : SystemBase => mSystems[typeof(T)] as T;
    }
}