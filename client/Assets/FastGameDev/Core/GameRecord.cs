using System;
using System.Collections.Generic;
using FastGameDev.Record;
using UnityEngine;

namespace FastGameDev.Core
{
    public class GameRecord: MonoBehaviour
    {
        private Dictionary<Type, RecordBase> mRecords = new Dictionary<Type, RecordBase>();
        
        internal bool IsInited { get; private set; }
        
        internal void Init()
        {
            foreach (var sys in GetComponentsInChildren<RecordBase>())
            {
                sys.Init();
                mRecords.Add(sys.GetType(), sys);
            }
            
            IsInited = true;
        }

        internal void Destroy()
        {
            IsInited = false;
        }

        public T Get<T>() where T : RecordBase => mRecords[typeof(T)] as T;
    }
}