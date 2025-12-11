using System;
using System.Collections.Generic;
using FastGameDev.Syztem;
using UnityEngine;

namespace FastGameDev.Core
{
    public class GameSystem: MonoBehaviour
    {
        private Dictionary<Type, SystemBase> mSystems = new Dictionary<Type, SystemBase>();
        
        internal bool IsInited { get; private set; }
        
        internal void Init()
        {
            foreach (var sys in GetComponentsInChildren<SystemBase>())
            {
                sys.Init();
                mSystems.Add(sys.GetType(), sys);
            }
            
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