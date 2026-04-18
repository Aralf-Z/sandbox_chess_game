using System;
using System.Collections;
using System.Collections.Generic;
using GameDev.Core;
using UnityEngine;

namespace Game
{
    public class TroopBfTileInfo : MonoBehaviour
    , IGetSystem
    {
        public GridPoint point;

        private TroopBattleSystem mTbfSystem;
        private SpriteRenderer mMask;
        
        private void Start()
        {
            mTbfSystem = this.System().Get<TroopBattleSystem>();
            
            mMask = transform.Find("mask").GetComponent<SpriteRenderer>();

            mMask.sortingOrder = SpriteOrderDefine.SQUAD_BATTLEFIELD_TILE + 1;
            mMask.color = new Color(mMask.color.r, mMask.color.g, mMask.color.b, 0f);
        }

        private void OnMouseDown()
        {
            mTbfSystem.SelectTile(point);
        }

        private void OnMouseEnter()
        {
            var oriColor = mMask.color;
            mMask.color = new Color(oriColor.r, oriColor.g, oriColor.b, 0.3f);
        }

        private void OnMouseExit()
        {
            var oriColor = mMask.color;
            mMask.color = new Color(oriColor.r, oriColor.g, oriColor.b, 0f);
        }
    }
}