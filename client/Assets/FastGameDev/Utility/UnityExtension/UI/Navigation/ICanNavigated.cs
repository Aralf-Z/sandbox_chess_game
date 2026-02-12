namespace FastGameDev.Utility.UnitExtension
{
    public interface ICanNavigated
    {
        INavSet NavSet { get; set; }
        bool Interactable { get; }
        int Index { get; set; }
        void SetShow(bool show);
        void OnFocused();
        void OnUnfocused();
    }
}