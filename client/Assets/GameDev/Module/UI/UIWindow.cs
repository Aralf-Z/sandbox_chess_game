using System;
using UnityEngine;

namespace GameDev.Module
{
    public abstract class UIWindow: UIElement
        , IUIWindow
    {
        public abstract EmUIOrder Order { get; }
    }
}