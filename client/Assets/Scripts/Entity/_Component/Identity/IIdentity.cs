namespace Game
{
    public interface IIdentity
    {
        /// <summary> 种族id </summary>
        int Race { get; }
        // /// <summary> 职业id </summary>
        // int Clasz { get; }
    }

    public interface IHaveIdentity
    {
        IIdentity Identity { get; }
    }
}