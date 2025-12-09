// using UnityEngine;
//
// namespace Game.Logic.WorldBind
// {
//     public sealed class NewGoBind: GameObjectBind
//     {
//         private static Transform sGoRoot;
//
//         public NewGoBind()
//         {
//             SelfGo = new GameObject();
//             SelfGo.transform.parent = sGoRoot ?? new GameObject("GoBind").transform;
//         }
//     }
// }