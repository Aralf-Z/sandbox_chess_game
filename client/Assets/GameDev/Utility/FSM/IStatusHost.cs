namespace GameDev.Utility.FSM
{
    public interface IStatusHost
    {
        void ChangeStatus<T>() where T: StatusBase;
    }
}