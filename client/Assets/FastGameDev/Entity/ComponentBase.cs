namespace FastGameDev.Entity
{
    public abstract class ComponentBase
    {
        protected internal EntityBase Host { get; internal set; }
        
        protected internal virtual void OnAdded()
        {
            
        }
    }
}