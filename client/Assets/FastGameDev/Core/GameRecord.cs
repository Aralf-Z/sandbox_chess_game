using UnityEngine;

namespace FastGameDev.Core
{
    public class GameRecord: MonoBehaviour
    {
        internal bool IsInited { get; private set; }
        
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