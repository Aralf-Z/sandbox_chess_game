using UnityEngine;

namespace GameDev.Module
{
    public class InputModule: MonoBehaviour
        ,IModule
    {
        public int InitOrder => InitOrderDefine.INPUT;
        
        public void Init()
        {
            
        }

        public void Deinit()
        {
            
        }

        public void OnUpdate(float dt)
        {
            
        }
    }
}