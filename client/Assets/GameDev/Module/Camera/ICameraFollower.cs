using GameDev.Utility.FSM;
using UnityEngine;

namespace GameDev.Module
{
    public interface ICameraFollower: 
        IStatusHost
    {
        Vector3 CameraPosition { get; }
        void Init();
        void OnUpdate(float dt);
    }
}