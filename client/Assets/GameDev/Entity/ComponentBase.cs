namespace GameDev.Entity
{
    public abstract class ComponentBase
    {
        public EntityBase Host { get; internal set; }
     
        public EmState State { get; protected set; } = EmState.Unready;
        
        /// <summary>
        /// 被添加时
        /// </summary>
        protected internal virtual void OnAdded()
        {
            State = EmState.Ready;
        }

        /// <summary>
        /// 宿主就绪时
        /// </summary>
        protected internal virtual void OnHostReady()
        {
            
        }
        
        /// <summary>
        /// 被移出时
        /// </summary>
        protected internal virtual void OnRemoved()
        {
            
        }
    }
}