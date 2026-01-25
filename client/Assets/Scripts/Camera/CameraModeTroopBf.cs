using FastGameDev.Utility.FSM;
using UnityEngine;

namespace Game
{
    public class CameraModeTroopBf: StatusBase
    {
        private GameCameraFollower mHost;
        
        public override void Init<T>(T host)
        {
            mHost =  host as GameCameraFollower;
        }

        public override void OnUpdate(float dt)
        {
            var dir = Vector3.zero;
            
            if (Input.GetKey(KeyCode.W))
            {
                dir += Vector3.up * mHost.moveSpeed * dt;    
            }

            if (Input.GetKey(KeyCode.S))
            {
                dir += Vector3.down * mHost.moveSpeed * dt;
            }

            if (Input.GetKey(KeyCode.A))
            {
                dir += Vector3.left * mHost.moveSpeed * dt;
            }

            if (Input.GetKey(KeyCode.D))
            {
                dir += Vector3.right * mHost.moveSpeed * dt;
            }

            mHost.transform.position += dir;
        }
    }
}