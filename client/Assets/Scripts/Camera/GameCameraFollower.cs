using System;
using FastGameDev.Module;
using UnityEngine;

namespace Game
{
    public class GameCameraFollower: MonoBehaviour
        , ICameraFollower
    {
        public Vector3 CameraPosition => transform.position + new Vector3(0, 0, -10);
        
        public void OnUpdate(float dt)
        {
            //transform.position += new Vector3(dt * -5, 0, 0);
        }
    }
}