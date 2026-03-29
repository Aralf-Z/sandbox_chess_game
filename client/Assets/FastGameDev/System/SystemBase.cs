using FastGameDev.Core;
using UnityEngine;

namespace FastGameDev.Syztem
{
    public abstract class SystemBase: 
        IGetModule
        , IGetNote
    {
        protected internal abstract void Init();
    }
}