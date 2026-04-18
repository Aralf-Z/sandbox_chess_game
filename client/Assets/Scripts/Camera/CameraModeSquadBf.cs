using GameDev.Core;
using GameDev.Utility.FSM;

namespace Game
{
    public class CameraModeSquadBf: StatusBase
        , IGetNote
    {
        private GameCameraFollower mHost;
        
        public override void Init<T>(T host)
        {
            mHost =  host as GameCameraFollower;
        }

        public override void OnEnter()
        {
            var note = this.Note().Get<SquadBattleNote>();
            //mHost.transform.position = note.bf.Model.Transform.position;
        }
    }
}