using GameDev.Helper;

namespace GameDev.Core
{
    public class FlowGameInit: FlowBase
    {
        private static GameApplication App => GameApplication.Instance;
        
        protected internal override void Init() { }

        protected internal override void Enter()
        {
            //todo 当发生阻塞时可以异步等
            Logger.LogInfo("初始化游戏模块", "流程");
            App.gameModule.Init();
            App.gameEntity.Init();
            App.gameLogic.Init();
            App.gameNote.Init();
            App.gameSystem.Init();
        }

        protected internal override void Check()
        {
            //todo 第一次check直接下一个流
            NextFlow();
        }

        protected override void Exit()
        {
            Logger.LogInfo("初始化游戏模块结束", "流程");
        }
    }
}