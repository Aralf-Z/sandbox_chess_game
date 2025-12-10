namespace Game
{
    public class SquadInfo: IInfo
    {
        public int ConfigId { get; }
        public string DisplayName { get; set; }

        public SquadInfo(string displayName)
        {
            ConfigId = 0;
            DisplayName = displayName;
        }
    }
}