using System;
using UnityEngine;

namespace FastGameDev.Module
{
    public abstract class UIWindow: UIElement
        , IUIWindow
    {
        public abstract EmUIOrder Order { get; }
    }
}