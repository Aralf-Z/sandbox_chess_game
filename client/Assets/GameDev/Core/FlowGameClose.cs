using GameDev.Helper;

namespace GameDev.Core
{
    public class FlowGameClose: FlowBase
    {
        private static GameApplication App => GameApplication.Instance;
        
        protected internal override void Init() { }

        protected internal override void Enter()
        {
            Logger.LogInfo("关闭游戏管理器", "流程");
            App.gameModule.Destroy();
            App.gameNote.Destroy();
            App.gameEntity.Destroy();
            App.gameLogic.Destroy();
            App.gameSystem.Destroy();
            
            App.ShutDown();
        }

        protected internal override void Check() { }

        protected override void Exit()
        {
            Logger.LogInfo("关闭游戏管理器结束", "流程");
        }
    }
}