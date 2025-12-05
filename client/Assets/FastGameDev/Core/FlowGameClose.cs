using FastGameDev.Helper;

namespace FastGameDev.Core
{
    public class FlowGameClose: FlowBase
    {
        private static GameApplication App => GameApplication.Instance;
        
        protected internal override void Init() { }

        protected internal override void Enter()
        {
            LogHelper.Info("关闭游戏管理器", "流程");
            App.gameModule.Destroy();
            App.gameRecord.Destroy();
            App.gameEntity.Destroy();
            App.gameLogic.Destroy();
            App.gameSystem.Destroy();
            
            App.ShutDownGame();
        }

        protected internal override void Check() { }

        protected override void Exit()
        {
            LogHelper.Info("关闭游戏管理器结束", "流程");
        }
    }
}