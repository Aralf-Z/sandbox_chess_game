using UnityEngine;

namespace FastGameDev.Core
{
    internal class GameRecord: MonoBehaviour
    {
        public bool IsInited { get; private set; }
        
        internal void Init()
        {
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
    }
}