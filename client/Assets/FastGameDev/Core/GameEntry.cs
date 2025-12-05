using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FastGameDev.Core
{
    public class GameEntry : MonoBehaviour
    {
        public GameApplication gameApplication;

        private void Start()
        {
            gameApplication.StartGame();
        }
    }
}