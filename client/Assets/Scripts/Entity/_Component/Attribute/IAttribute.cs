namespace Game
{
    public interface IAttribute
    {
        float this [EmFixedAttri attribute] { get; set; }
        float this [EmResAttri attribute] { get; set; }
    }

    public interface IHaveAttribute
    {
        IAttribute Attribute { get; }
    }
}