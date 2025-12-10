using FastGameDev.Utility.FSM;
using UnityEngine;

namespace FastGameDev.Module
{
    public interface ICameraFollower: 
        IStatusHost
    {
        Vector3 CameraPosition { get; }
        void Init();
        void OnUpdate(float dt);
    }
}