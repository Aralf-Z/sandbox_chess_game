using UnityEngine;

namespace FastGameDev.Core
{
    public abstract class FlowBase: MonoBehaviour
    {
        [SerializeField] public FlowBase nextFlow;
        
        protected static GameFlow Flow => GameApplication.Instance.gameFlow;
        
        protected internal abstract void Init();
        protected internal abstract void Enter();
        protected internal abstract void Check();
        protected abstract void Exit();

        protected void NextFlow()
        {
            Exit();
            Flow.curFlow = nextFlow;
            nextFlow.Enter();
        }
    }
}