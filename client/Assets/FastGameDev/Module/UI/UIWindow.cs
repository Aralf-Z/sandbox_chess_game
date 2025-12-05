using System;
using UnityEngine;

namespace FastGameDev.Module
{
    public abstract class UIWindow: UIElement
        , IUIWindow
    {
        public EmUIOrder Order { get; protected set; }
    }
}