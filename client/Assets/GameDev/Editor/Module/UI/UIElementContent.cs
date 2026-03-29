using System.Collections.Generic;
using GameDev.Module;

namespace GameDev.Editor
{
    internal class UIElementContent
    {
        public readonly UIElement root;
        public readonly List<UIElement> elements = new ();
        public readonly List<FieldBind> fieldBinds = new ();
        
        public UIElementContent(UIElement root)
        {
            this.root = root;
        }
    }
}