using System;
using System.Collections.Generic;
using System.Linq;
using Game.Config.Character;
using GameDev.Core;
using GameDev.Entity;
using UnityEngine;

namespace Game
{
    public class SquadBfModel: ComponentBase
    {
        public WorldModel Model { get; private set; }

        private readonly Dictionary<SquadPos, SquadBfTileInfo> mAllyTileInfoMap = new();

        private readonly Dictionary<SquadPos, SquadBfTileInfo> mEnemyTileInfoMaps = new();
        
        protected override void OnAdded()
        {
            Model = Host.Get<WorldModel>();
            Model.Evt_OnLoaded += OnModelLoaded;
        }

        protected override void OnRemoved()
        {
            Model.Evt_OnLoaded -= OnModelLoaded;
        }

        private void OnModelLoaded()
        {
            foreach (var info in Model.Transform.Find("Ally").GetComponentsInChildren<SquadBfTileInfo>())
            {
                mAllyTileInfoMap.Add(new SquadPos(info.row, info.col), info);
            }
            foreach (var info in Model.Transform.Find("Enemy").GetComponentsInChildren<SquadBfTileInfo>())
            {
                mEnemyTileInfoMaps.Add(new SquadPos(info.row, info.col), info);
            }
        }

        public Vector3 TryTileToWorldPosition(EmSquadStand stand, SquadPos pos)
        {
            return stand switch
            {
                EmSquadStand.Ally => mAllyTileInfoMap.TryGetValue(pos, out var tileInfo) ? tileInfo.transform.position : Vector3.zero,
                EmSquadStand.Enemy => mEnemyTileInfoMaps.TryGetValue(pos, out var tileInfo) ? tileInfo.transform.position : Vector3.zero,
                _ => throw new ArgumentOutOfRangeException(nameof(stand), stand, null)
            };
        }
        
        public Vector3 TryTileToWorldPosition(EmSquadStand stand, int row, int col)
        {
            return TryTileToWorldPosition(stand, new SquadPos(row, col));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stand"></param>
        /// <param name="type"></param>
        /// <param name="pos"> 取左上角的瓦片位置 </param>
        /// <returns></returns>
        public Vector3 TryTileWithBodyTypeToWorldPosition(EmSquadStand stand, EmBodyType type, SquadPos pos)
        {
            switch (type)
            {
                case EmBodyType.Small: 
                    return TryTileToWorldPosition(stand, pos);
                case EmBodyType.Medium:
                    return (TryTileToWorldPosition(stand, pos) + TryTileToWorldPosition(stand, new SquadPos(pos.row, pos.col + 1))) / 2f;
                case EmBodyType.Large:
                    var pos0 = TryTileToWorldPosition(stand, pos); //左上
                    var pos1 = TryTileToWorldPosition(stand, new SquadPos(pos.row, pos.col + 2));//右上
                    var pos2 = TryTileToWorldPosition(stand, new SquadPos(pos.row - 1, pos.col));//左下
                    var pos3 = TryTileToWorldPosition(stand, new SquadPos(pos.row - 1, pos.col + 2));//右下
                    var pos4 = (pos0 + pos1) / 2f;
                    var pos5 = (pos2 + pos3) / 2f;
                    return (pos4 + pos5) / 2f;
                case EmBodyType.Gargantuan:
                    return stand switch
                    {
                        EmSquadStand.Ally => mAllyTileInfoMap.First().Value.transform.position,
                        EmSquadStand.Enemy => mEnemyTileInfoMaps.First().Value.transform.position,
                        _ => throw new ArgumentOutOfRangeException(nameof(stand), stand, null)
                    };
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}