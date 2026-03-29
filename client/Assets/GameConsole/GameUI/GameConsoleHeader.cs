using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace ConsoleTerminal.GameUI
{
    [RequireComponent(typeof(Image))]
    public class GameConsoleHeader : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler,
        IPointerUpHandler, IPointerMoveHandler
    {
        [SerializeField] private Color hoverColor = Color.white;
        private Image mHeaderImage;
        private Color mNormalColor;
        private Action<Vector2> mMovCb;

        private bool mShouldMov;
        private Vector2 mStartPos;

        public void Init(Action<Vector2> movCb = null)
        {
            this.mMovCb = movCb;
            mHeaderImage = GetComponent<Image>();
            if (mHeaderImage == null)
            {
                throw new System.Exception("GameConsoleHeader must attach to a GameObject with Image component");
            }

            mNormalColor = mHeaderImage.color;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            mHeaderImage.color = hoverColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            mHeaderImage.color = mNormalColor;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            mShouldMov = true;
            mStartPos = eventData.position;
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            if (mShouldMov)
            {
                Vector2 delta = eventData.position - mStartPos;
                mMovCb?.Invoke(delta);
                mStartPos = eventData.position;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            mShouldMov = false;
        }
    }
}