// using Game.Core.Interface;
// using UnityEngine;
// using ZToolKit;
//
// namespace Game.Logic.WorldBind
// {
//     public abstract class UnityCameraBind:
//         ICameraBind
//     {
//         protected virtual float Zoom {get;set;}
//         
//         public Camera Camera { get; protected set; }
//         
//         public (float x, float y) Position
//         {
//             get => (Camera.transform.position.x, Camera.transform.position.y); 
//             set => Camera.transform.position = new Vector3(value.x, value.y, Zoom);
//         }
//         public bool Enabled
//         {
//             get => Camera.enabled;
//             set => Camera.enabled = value;
//         }
//
//         public void Update(float dt)
//         {
//             OnUpdate(dt);
//         }
//
//         protected abstract void OnUpdate(float dt);
//
//         public (float x, float y) WorldPos2UIPos(UIScreen uiRoot, float worldX, float worldY)
//         {
//             if (uiRoot.TryGetComponent<RectTransform>(out var trans))
//             {
//                 var wordPosition = new Vector3(worldX, worldY, 0);
//                 var screenPos = Camera.WorldToScreenPoint(wordPosition);
//                 var canvasCamera = trans.GetComponentInParent<Canvas>().worldCamera;
//
//                 RectTransformUtility.ScreenPointToLocalPointInRectangle(
//                     trans,
//                     screenPos,
//                     canvasCamera,
//                     out var localPos);
//                 return (localPos.x, localPos.y);
//             }
//
//             throw new CameraBindException($"invalid uiRoot type: {uiRoot.GetType()}, it must be RectTransform");
//         }
//     }
// }