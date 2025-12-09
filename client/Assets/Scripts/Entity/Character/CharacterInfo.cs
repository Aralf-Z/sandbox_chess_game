namespace Game
{
    public class CharacterInfo: IInfo
    {
        public int ConfigId { get; }
        public string DisplayName { get; set; }

        public CharacterInfo(int configId, string displayName)
        {
            ConfigId = configId;
            DisplayName = displayName;
        }
    }
}