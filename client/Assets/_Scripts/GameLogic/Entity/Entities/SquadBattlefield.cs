// using Game.Core.Combat;
// using Game.Core.Interface;
// using Game.Logic.WorldBind;
// using UnityEngine;
//
// namespace Game.Logic
// {
//     public sealed class SquadBattlefield:
//         ISquadBattlefield
//     {
//         private static readonly Vector2 sBfPosition = new Vector2(-100, -100);
//         private readonly GameObject mRoot;
//         private ISquad mAlly;
//         private ISquad mEnemy;
//         private readonly SquadBattlefieldBind mSbfb;
//         private readonly SquadBfCameraBind mSelfCamera;
//         
//         public SquadBattlefield()
//         {
//             mRoot = new GameObject("SquadBattlefield");
//             mSbfb = new SquadBattlefieldBind();
//             mSelfCamera =  new SquadBfCameraBind();
//             
//             mSbfb.SelfGo.transform.SetParent(mRoot.transform);
//             mSelfCamera.Camera.transform.SetParent(mRoot.transform);
//             mSelfCamera.Camera.transform.localPosition = new Vector3(0, 0, -10);
//             
//             mRoot.transform.position = sBfPosition;
//
//             CameraBind.Enabled = false;
//         }
//
//         public IObjectBind ObjectBind => mSbfb;
//         public ICameraBind CameraBind => mSelfCamera;
//         
//         public void Enter(ISquad ally, ISquad enemy)
//         {
//             mAlly = ally;
//             mEnemy = enemy;
//         }
//     }
// }