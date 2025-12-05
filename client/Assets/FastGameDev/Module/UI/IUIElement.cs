using UnityEngine;

namespace FastGameDev.Module
{
    public interface IUIElement
    {
        bool IsOpening { get; }
        void Open();
        void Hide();
        void Close();
    }
}