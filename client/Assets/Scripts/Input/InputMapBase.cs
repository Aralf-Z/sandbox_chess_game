using GameDev.Utility.FSM;

namespace Game
{
    public abstract class InputMapBase: StatusBase
    {
        protected InputManager mMgr;
            
        public override void Init<T>(T host)
        {
            mMgr = host as InputManager;
        }
    }
}