using System;
using GameDev.Helper;
using UnityEngine;

namespace Game
{
    public class CharacterOrder: MonoBehaviour
    {
        private SpriteRenderer mSpriteRenderer;

        private void Start()
        {
            mSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            mSpriteRenderer.sortingOrder = 1000 - (transform.position.y * 10).Round() + SpriteOrderDefine.TROOP_BATTLEFIELD_SQUAD;
        }
    }
}