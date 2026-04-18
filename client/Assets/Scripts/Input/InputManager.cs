using System;
using System.Collections.Generic;
using GameDev.Core;
using GameDev.Utility.FSM;
using UnityEngine;

namespace Game
{
    public class InputManager: MonoBehaviour
        , IStatusHost
        , IGetSystem
        , IGetNote
    {
        public void Init()
        {
            DontDestroyOnLoad(gameObject);
            
            foreach (var map in mMaps.Values) map.Init(this);
            
            ChangeStatus<SelectSquadMap>();
        }

        private void Update()
        {
            mCurrentMap?.OnUpdate(Time.deltaTime);
        }
        
        private readonly Dictionary<Type, InputMapBase> mMaps = new Dictionary<Type, InputMapBase>()
        {
            [typeof(SelectSquadMap)] = new SelectSquadMap(),
        };
        
        private InputMapBase mCurrentMap;
        
        public void ChangeStatus<T>() where T : StatusBase
        {
            mCurrentMap?.OnExit();
            mCurrentMap = mMaps[typeof(T)];
            mCurrentMap.OnEnter();
        }
    }
}