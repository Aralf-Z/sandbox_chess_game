using UnityEngine;

namespace FastGameDev.Core
{
    public class GameLogic: MonoBehaviour
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
                
            }
        }

        internal void OnFixedUpdate(float dt)
        {
            if (mIsInited)
            {
                
            }
        }
    }
}