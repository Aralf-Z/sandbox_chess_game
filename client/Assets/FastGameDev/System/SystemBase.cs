using FastGameDev.Core;
using UnityEngine;

namespace FastGameDev.Syztem
{
    public abstract class SystemBase: MonoBehaviour
        , IGetModule
    {
        protected internal abstract void Init();
    }
}