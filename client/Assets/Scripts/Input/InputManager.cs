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
        private TroopBattleSystem mSystem;
        private TroopBattlefieldNote mNote;

        public void Init()
        {
            DontDestroyOnLoad(gameObject);
            
            mSystem = this.System().Get<TroopBattleSystem>();
            mNote = this.Note().Get<TroopBattlefieldNote>();
            
            foreach (var map in mMaps.Values) map.Init(this);
            
            ChangeStatus<SelectSquadMap>();
        }

        private void Update()
        {
            mCurrentMap?.OnUpdate(Time.deltaTime);
        }
        

        private abstract class InputMap: StatusBase
        {
            protected InputManager mMgr;
            
            public override void Init<T>(T host)
            {
                mMgr = host as InputManager;
            }
        }

        private class SelectSquadMap : InputMap
        {
            public override void OnUpdate(float dt)
            {
                var zero = new GridPoint(0, 0);
                var select = zero;
                select += Input.GetKeyDown(KeyCode.UpArrow) ? new GridPoint(0, 1) : zero;
                select += Input.GetKeyDown(KeyCode.DownArrow) ? new GridPoint(0, -1) : zero;
                select += Input.GetKeyDown(KeyCode.LeftArrow) ? new GridPoint(-1, 0) : zero;
                select += Input.GetKeyDown(KeyCode.RightArrow) ? new GridPoint(1, 0) : zero;
            
                mMgr.mSystem.SelectTile(mMgr.mNote.currentPoint + select);
            }
        }

        private readonly Dictionary<Type, InputMap> mMaps = new Dictionary<Type, InputMap>()
        {
            [typeof(SelectSquadMap)] = new SelectSquadMap(),
        };
        
        private InputMap mCurrentMap;
        
        public void ChangeStatus<T>() where T : StatusBase
        {
            mCurrentMap?.OnExit();
            mCurrentMap = mMaps[typeof(T)];
            mCurrentMap.OnEnter();
        }
    }
}