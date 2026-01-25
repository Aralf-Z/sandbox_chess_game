using System;
using System.Collections.Generic;
using FastGameDev.Module;
using FastGameDev.Utility.FSM;
using UnityEngine;

namespace Game
{
    public class GameCameraFollower: MonoBehaviour
        , ICameraFollower
    {
        public float moveSpeed = 5;
        
        private Dictionary<Type, StatusBase> mStatusMap;
        private StatusBase mCurStatus;
        
        public Vector3 CameraPosition => transform.position + new Vector3(0, 0, -10);

        public void Init()
        {
            mStatusMap = new Dictionary<Type, StatusBase>()
            {
                [typeof(CameraModeTroopBf)] = new CameraModeTroopBf(),
                [typeof(CameraModeSquadBf)] = new CameraModeSquadBf(),
            };
            foreach (var (_,status) in mStatusMap)
            {
                status.Init(this);
            }
        }

        public void OnUpdate(float dt)
        {
            mCurStatus?.OnUpdate(dt);
        }


        public void ChangeStatus<T>() where T : StatusBase
        {
            mCurStatus?.OnExit();
            mCurStatus = mStatusMap[typeof(T)];
            mCurStatus.OnEnter();
        }
    }
}