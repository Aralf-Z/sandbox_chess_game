using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FastGameDev.Core
{
    internal class GameEntity : MonoBehaviour
    {
        private bool mIsInited;
        
        internal void Init()
        {
            mIsInited = true;
        }

        internal void Destroy()
        {
            mIsInited = false;
        }
        
        internal void OnUpdate(float dt)
        {
            if (mIsInited)
            {
                //todo 
            }
        }

        internal void OnFixedUpdate(float dt)
        {
            if (mIsInited)
            {
                //todo 
            }
        }
    }
}