using GameDev.Core;
using UnityEngine;

namespace Game
{
    public class SelectSquadMap : InputMapBase
    {
        private TroopBattleSystem mTbfSystem;
        private TroopBattleNote mTbfNote;

        public override void Init<T>(T host)
        {
            base.Init(host);
            
            mTbfSystem = mMgr.System().Get<TroopBattleSystem>();
            mTbfNote = mMgr.Note().Get<TroopBattleNote>();
        }

        public override void OnUpdate(float dt)
        {
            mTbfSystem.SelectTile(InputCheck());
        }

        private GridPoint InputCheck()
        {
            var zero = new GridPoint(0, 0);
            var select = zero;
            select += Input.GetKeyDown(KeyCode.UpArrow) ? new GridPoint(0, 1) : zero;
            select += Input.GetKeyDown(KeyCode.DownArrow) ? new GridPoint(0, -1) : zero;
            select += Input.GetKeyDown(KeyCode.LeftArrow) ? new GridPoint(-1, 0) : zero;
            select += Input.GetKeyDown(KeyCode.RightArrow) ? new GridPoint(1, 0) : zero;
            
            return mTbfNote.currentPoint + select;
        }
    }
}