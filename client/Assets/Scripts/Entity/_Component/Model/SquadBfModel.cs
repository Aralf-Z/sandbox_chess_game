using System;
using System.Collections.Generic;
using FastGameDev.Core;
using FastGameDev.Entity;
using UnityEngine;

namespace Game
{
    public class SquadBfModel: ComponentBase
        , IGetEntity
    {
        private readonly Dictionary<(EmSquadStand, int row, int col), SquadBfTileEntity> mTiles = new();

        private Transform mAllyRoot;//固定在右边

        private Transform mEnemyRoot;//固定在左边

        public WorldModel Model { get; private set; }
        
        protected override void OnAdded()
        {
            const int col = BattlefieldDefine.SQUAD_BF_COL_COUNT;
            const int row = BattlefieldDefine.SQUAD_BF_ROW_COUNT;
            
            Model = Host.Get<WorldModel>();
            
            mAllyRoot = new GameObject("Ally").transform;
            mAllyRoot.transform.SetParent(Model.Transform);
            mAllyRoot.transform.localPosition = Vector3.left * 7;
            
            
            mEnemyRoot = new GameObject("Enemy").transform;
            mEnemyRoot.transform.SetParent(Model.Transform);
            mEnemyRoot.transform.localPosition = Vector3.right * 7;
            
            for (var x = 0; x < col; x++)
            {
                for (var y = 0; y < row; y++)
                {
                    var colIndex = x + 1;
                    var rowIndex = y + 1;
                    var tileConfig = SquadBfTileEntity.GetConfig(colIndex, rowIndex);
                    var pos = GetLocalPos(rowIndex, colIndex);
                    
                    var allyTile = this.Entity().Require<SquadBfTileEntity>(tileConfig);
                    var enemyTile = this.Entity().Require<SquadBfTileEntity>(tileConfig);
                    
                    allyTile.Model.Transform.SetParent(mAllyRoot);
                    allyTile.Model.Transform.localPosition = pos;
                    enemyTile.Model.Transform.SetParent(mEnemyRoot);
                    enemyTile.Model.Transform.localPosition = pos;
                    
                    mTiles[(EmSquadStand.Ally, rowIndex, colIndex)] = allyTile;
                    mTiles[(EmSquadStand.Enemy, rowIndex, colIndex)] = enemyTile;
                }
            }
            
            mAllyRoot.transform.eulerAngles = Vector3.forward * -90;
            mEnemyRoot.transform.eulerAngles = Vector3.forward * 90;
        }
        
        public Vector3 GetWorldPos(EmSquadStand stand, int row, int col)
        {
            return mTiles[(stand, row, col)].Model.Transform.position;
        }
        
        private static Vector3 GetLocalPos(int row, int col)
        {
            const float x0 = - (BattlefieldDefine.SQUAD_BF_COL_COUNT - 1) / 2f;
            const float y0 = - (BattlefieldDefine.SQUAD_BF_ROW_COUNT - 2) / 2f;

            return new Vector3(x0 + col - 1, y0 + 2 * (BattlefieldDefine.SQUAD_BF_ROW_COUNT + 1 - row), 0);
        }
    }
}