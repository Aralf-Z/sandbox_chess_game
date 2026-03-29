using System;
using System.Buffers;
using System.Collections.Generic;
using GameDev.Core;
using GameDev.Entity;
using UnityEngine;

namespace Game
{
    public class TroopBfEntity: EntityBase
    , IWorldModel
    {
        private GameObject mOnSelectTipTile;

        protected override string Tag =>　"troop_battlefield";
        
        protected override void Init(int config)
        {
            Grid = AddBuiltInComponent<TroopBfGrid>();
            Model = AddBuiltInComponent<WorldModel>();
            SelfModel = AddBuiltInComponent<TroopBfModel>();
        }
        
        public TroopBfGrid Grid { get; private set; }
        public WorldModel Model { get; private set; }
        public TroopBfModel SelfModel { get; private set; }
    }
}