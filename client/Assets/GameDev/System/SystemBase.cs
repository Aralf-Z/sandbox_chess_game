using GameDev.Core;
using UnityEngine;

namespace GameDev.Syztem
{
    public abstract class SystemBase: 
        IGetModule
        , IGetNote
    {
        protected internal abstract void Init();
    }
}