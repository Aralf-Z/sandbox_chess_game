// using System.Collections.Generic;
// using Game.Core.Config.GameActor;
// using Game.Core.Combat;
// using Game.Core.Interface;
// using Game.Logic.WorldBind;
//
// namespace Game.Logic
// {
//     public class SquadGrid
//         : ISquadGrid
//     {
//         private Dictionary<(int x, int y), IActor> mGrid = new Dictionary<(int x, int y), IActor>();
//
//         public SquadGrid()
//         {
//             for (var x = 1; x <= 6; x++)
//             {
//                 for (var y = 1; y <= 6; y++)
//                     mGrid[(x,y)] = null;
//             }
//         }
//
//         public string Name { get; set; }
//         public IEnumerable<IActor> Actors => mGrid.Values;
//
//         public bool Set(int row, int column, IActor actor)
//         {
//             var xy = Rc2Xy(row, column);
//             
//             if (CheckPosition(xy.x, xy.y, actor))
//             {
//                 var bodyType = actor.Identity.Race.BodyType;
//                 
//                 switch (bodyType)
//                 {
//                     case EmBodyType.Small: SetRect(xy.x, xy.y, 1, 2, actor); break;//1*2
//                     case EmBodyType.Medium: SetRect(xy.x, xy.y, 2, 2, actor); break;//2*2
//                     case EmBodyType.Large: SetRect(xy.x, xy.y-2, 3, 4, actor); break;//3*4
//                     case EmBodyType.Gargantuan: SetRect(xy.x, xy.y-4, 6, 6, actor); break;//6*6
//                 }
//                 
//                 return true;
//             }
//             
//             return false;
//         }
//
//         public (float x, float y) GetCenterPosition(int row, int column, IActor actor)
//         {
//             var xy = Rc2Xy(row, column);
//
//             if (CheckPosition(xy.x, xy.y, actor))
//             {
//                 var bodyType = actor.Identity.Race.BodyType;
//                 var pos = bodyType switch
//                 {
//                     EmBodyType.Small => (xy.x - .5f, xy.y),
//                     EmBodyType.Medium => (xy.x, xy.y),
//                     EmBodyType.Large => (xy.x + .5f, xy.y - 1f),
//                     EmBodyType.Gargantuan => (xy.x + 2f, xy.y - 2f),
//                     _ => (0, 0),
//                 };
//                 
//                 return (pos.Item1, pos.Item2);
//             }
//
//             return (0f, 0f);
//         }
//         
//         public bool Move(int row, int column, IActor actor)
//         {
//             //todo 移动单位的检查
//             return false;
//         }
//         
//         public IActor Get(int x, int y)
//         {
//             return mGrid[(x, y)];
//         }
//
//         private (int x, int y) Rc2Xy(int row, int column)
//         {
//             return row switch
//             {
//                 1 => (column, 5),
//                 2 => (column, 3),
//                 3 => (column, 1),
//                 _ => (0,0),
//             };
//         }
//         
//         private bool CheckPosition(int x, int y, IHaveIdentity host)
//         {
//             var bodyType = host.Identity.Race.BodyType;
//
//             return bodyType switch
//             {
//                 EmBodyType.Small => CheckRect(x, y, 1, 2),//1*2
//                 EmBodyType.Medium => CheckRect(x, y, 2, 2),//2*2
//                 EmBodyType.Large => CheckRect(x, y-2, 3, 4),//3*4
//                 EmBodyType.Gargantuan => CheckRect(x, y-4, 6, 6),//6*6
//                 _ => false
//             };
//         }
//
//         private bool CheckRect(int x, int y, int w, int h)
//         {
//             for (var i = 0; i < w; i++)
//             {
//                 for (var j = 0; j < h; j++)
//                 {
//                     if (Check(i + x, j + y))
//                     {
//                         return false;
//                     } 
//                 }
//             }
//
//             return true;
//
//             bool Check(int xp, int yp) =>  mGrid.TryGetValue((xp, yp), out var id) && id != null;
//         }
//         
//         private void SetRect(int x, int y, int w, int h, IActor actor)
//         {
//             for (var i = 0; i < w; i++)
//             {
//                 for (var j = 0; j < h; j++)
//                 {
//                     var xp = x + i;
//                     var yp = y + j;
//                     mGrid[(xp, yp)] = actor;
//                 }
//             }
//         }
//     }
// }