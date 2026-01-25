using System.Collections.Generic;
using FastGameDev.Entity;
using UnityEngine;

namespace Game
{
    public class SquadBfTileEntity: EntityBase
        , IWorldModel
    {
        private static readonly Dictionary<int, Color> Colors = new Dictionary<int, Color>
        {
            { 0,  new Color(0.90f, 0.20f, 0.20f) }, // 红
            { 1,  new Color(0.95f, 0.45f, 0.15f) }, // 橙
            { 2,  new Color(0.95f, 0.75f, 0.20f) }, // 黄
            { 3,  new Color(0.55f, 0.80f, 0.25f) }, // 黄绿
            { 4,  new Color(0.25f, 0.75f, 0.45f) }, // 绿
            { 5,  new Color(0.20f, 0.75f, 0.75f) }, // 青绿

            { 6,  new Color(0.20f, 0.65f, 0.85f) }, // 青
            { 7,  new Color(0.25f, 0.45f, 0.90f) }, // 天蓝
            { 8,  new Color(0.30f, 0.30f, 0.85f) }, // 蓝
            { 9,  new Color(0.45f, 0.30f, 0.85f) }, // 蓝紫
            { 10, new Color(0.65f, 0.30f, 0.85f) }, // 紫
            { 11, new Color(0.80f, 0.30f, 0.65f) }, // 紫红

            { 12, new Color(0.85f, 0.35f, 0.35f) }, // 深红
            { 13, new Color(0.85f, 0.55f, 0.35f) }, // 棕橙
            { 14, new Color(0.70f, 0.70f, 0.35f) }, // 卡其黄
            { 15, new Color(0.35f, 0.70f, 0.55f) }, // 青灰绿
            { 16, new Color(0.35f, 0.55f, 0.70f) }, // 灰蓝
            { 17, new Color(0.60f, 0.60f, 0.60f) }, // 中性灰
        };
        
        public GridPoint Point { get; private set;}
        
        public WorldModel Model { get; private set; }
        
        protected override string Tag => "squad_tile";
        
        protected override void Init(int config)
        {
            var x = config / 100;
            var y = config % 100;
            
            Point = new GridPoint(x, y);
            Model = AddBuiltInComponent<WorldModel>();
            Model.name = "squadBfTile";
            Model.Load();
            
            var spriteRenderer = Model.Go.GetComponentInChildren<SpriteRenderer>();
            spriteRenderer.color = Colors[x + y];
            spriteRenderer.sortingOrder = SpriteOrderDefine.SQUAD_BATTLEFIELD_TILE;
        }

        public static int GetConfig(int x, int y) => x * 100 + y;
    }
}