using System;
using UnityEngine;
namespace FastGameDev.Core
{
    public class GameApplication: MonoBehaviour
    {
        public static GameApplication Instance;
        
        [SerializeField] internal GameNote gameNote;
        [SerializeField] internal GameEntity gameEntity;
        [SerializeField] internal GameLogic  gameLogic;
        [SerializeField] internal GameModule gameModule;
        [SerializeField] internal GameSystem gameSystem;
        [SerializeField] internal GameFlow   gameFlow;

        public void StartGame()
        {
            Instance = this;
            gameFlow.Init();
        }

        private void Update()
        {
            var dt = Time.deltaTime;
            
            gameModule.OnUpdate(dt);
            gameSystem.OnUpdate(dt);
            gameLogic.OnUpdate(dt);
        }

        private void FixedUpdate()
        {
            var dt = Time.fixedDeltaTime;
            
            gameFlow.Update();
            gameModule.OnFixedUpdate(dt);
            gameSystem.OnFixedUpdate(dt);
            gameLogic.OnFixedUpdate(dt);
        }

        public void ShutDown()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}