using System;
using System.Collections.Generic;
using GameDev.Core;
using GameDev.Entity;
using UnityEngine;

namespace Game
{
    public class SquadBfModel: ComponentBase
        , IGetEntity
    {
        //todo tile 处理
        //private readonly Dictionary<(EmSquadStand, int row, int col), SquadBfTileEntity> mTiles = new();

        private Transform mAllyRoot;//固定在右边

        private Transform mEnemyRoot;//固定在左边

        public WorldModel Model { get; private set; }

        protected override void OnAdded()
        {
            Model = Host.Get<WorldModel>();
            Model.Evt_OnLoaded += OnModelLoaded;
        }

        private void OnModelLoaded()
        {

        }
        
        // public Vector3 GetWorldPos(EmSquadStand stand, int row, int col)
        // {
        //     return mTiles[(stand, row, col)].Model.Transform.position;
        // }
        
       
    }
}