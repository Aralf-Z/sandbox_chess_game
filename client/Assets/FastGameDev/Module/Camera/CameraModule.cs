using UnityEngine;

namespace FastGameDev.Module
{
    public class CameraModule: MonoBehaviour
        ,IModule
    {
        private Camera mMain;
        private ICameraFollower mFollower;
        
        int IModule.InitOrder => InitOrderDefine.CAMERA;

        void IModule.Init()
        {
            mMain = Camera.main;
            mFollower = transform.GetComponentInChildren<ICameraFollower>();
        }

        void IModule.Deinit()
        {
            mMain = null;
        }
        
        void IModule.OnUpdate(float dt)
        {
            mFollower.OnUpdate(dt);
            mMain.transform.position = mFollower.CameraPosition;
        }
    }
}