using UnityEngine;

namespace FastGameDev.Module
{
    public interface ICameraFollower
    {
        Vector3 CameraPosition { get; }
        void OnUpdate(float dt);
    }
}