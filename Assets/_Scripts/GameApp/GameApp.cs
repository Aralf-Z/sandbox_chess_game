using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZToolKit;
using ZToolKit.UnityImpl;

public class GameApp : SingletonDontDestroy<GameApp>
{
    private Action<float> mUpdateAct;
    
    protected override void OnAwake()
    {
        
    }

    protected override void OnStart()
    {
        
    }

    public void RunApp()
    {
        if (GameConfig.IsConsoleActive)
        {
            
        }
    }
    
    private void Update()
    {
        mUpdateAct?.Invoke(Time.deltaTime);
    }
}
