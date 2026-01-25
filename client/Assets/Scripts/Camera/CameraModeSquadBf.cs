using FastGameDev.Core;
using FastGameDev.Utility.FSM;

namespace Game
{
    public class CameraModeSquadBf: StatusBase
        , IGetRecord
    {
        private GameCameraFollower mHost;
        
        public override void Init<T>(T host)
        {
            mHost =  host as GameCameraFollower;
        }

        public override void OnEnter()
        {
            var record = this.Record().Get<SquadBattlefieldRecord>();
            mHost.transform.position = record.bf.Model.Transform.position;
        }
    }
}