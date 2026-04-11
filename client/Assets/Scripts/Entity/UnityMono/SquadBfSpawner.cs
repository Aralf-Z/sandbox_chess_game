using UnityEngine;

namespace Game
{
    public class SquadBfSpawner: MonoBehaviour
    {
        public Color[][] mColors = new Color[][]
        {
            new Color[]
            {
                // ===== 前锋（盾兵 / 重骑兵 / 圣骑士）=====
                new Color(0.45f, 0.47f, 0.48f),
                new Color(0.38f, 0.40f, 0.42f),
                new Color(0.50f, 0.48f, 0.42f),
                new Color(0.33f, 0.35f, 0.36f),
                new Color(0.42f, 0.44f, 0.46f),
                new Color(0.29f, 0.30f, 0.31f),
            },
            new Color[]
            {
                // ===== 前卫（剑士 / 枪兵 / 战士）=====
                new Color(0.48f, 0.36f, 0.32f),
                new Color(0.48f, 0.30f, 0.27f),
                new Color(0.50f, 0.40f, 0.36f),
                new Color(0.37f, 0.33f, 0.30f),
                new Color(0.44f, 0.34f, 0.31f),
                new Color(0.37f, 0.26f, 0.24f),
            },
            new Color[]
            {
                // ===== 远程（弓箭手 / 游侠 / 牧师 / 圣职 / 支援 / 法师 / 术士 / 学者）=====
                new Color(0.34f, 0.40f, 0.33f),
                new Color(0.29f, 0.36f, 0.30f),
                new Color(0.38f, 0.43f, 0.35f),
                new Color(0.25f, 0.31f, 0.26f),
                new Color(0.42f, 0.46f, 0.38f),
                new Color(0.22f, 0.33f, 0.23f),
            },
        };

        public Sprite tileSprite;
        
        private void Spawn()
        {
            const int col = BattlefieldDefine.SQUAD_BF_COL_COUNT;
            const int row = BattlefieldDefine.SQUAD_BF_ROW_COUNT;
            
            var allyRoot = new GameObject("Ally").transform;
            allyRoot.transform.SetParent(transform);
            allyRoot.transform.localPosition = Vector3.left * 7;
            
            
            var enemyRoot = new GameObject("Enemy").transform;
            enemyRoot.transform.SetParent(transform);
            enemyRoot.transform.localPosition = Vector3.right * 7;
            
            for (var x = 0; x < col; x++)
            {
                for (var y = 0; y < row; y++)
                {
                    var colIndex = x + 1;
                    var rowIndex = y + 1;
                    var pos = GetLocalPos(rowIndex, colIndex);
                    var allyTile = SpawnTile(x, y,$"({rowIndex}, {colIndex})", allyRoot);
                    var enemyTile = SpawnTile(x, y,$"({rowIndex}, {colIndex})", enemyRoot);

                    allyTile.transform.localPosition = pos;
                    enemyTile.transform.localPosition = pos;
                }
            }
            
            allyRoot.transform.eulerAngles = Vector3.forward * -90;
            enemyRoot.transform.eulerAngles = Vector3.forward * 90;

            GameObject SpawnTile(int x, int y, string tileName, Transform parent)
            {
                var go = new GameObject(tileName);
                var model = new GameObject("model");
                var render = model.AddComponent<SpriteRenderer>();
                render.sortingOrder = SpriteOrderDefine.SQUAD_BATTLEFIELD_TILE;
                render.color = mColors[y][x];
                go.transform.SetParent(parent);
                model.transform.SetParent(go.transform);

                render.transform.localScale = new Vector3(0.95f, 1.9f, 0.95f);
                render.sprite = tileSprite;

                return go;
            }
        }
        
        private static Vector3 GetLocalPos(int row, int col)
        {
            const float x0 = - (BattlefieldDefine.SQUAD_BF_COL_COUNT - 1) / 2f;
            const float y0 = - (BattlefieldDefine.SQUAD_BF_ROW_COUNT - 2) / 2f;

            return new Vector3(x0 + col - 1, y0 + 2 * (BattlefieldDefine.SQUAD_BF_ROW_COUNT + 1 - row), 0);
        }

#if UNITY_EDITOR
        [UnityEditor.CustomEditor(typeof(SquadBfSpawner))]
        public class SquadBfSpawnerEditor : UnityEditor.Editor
        {
            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();

                if (GUILayout.Button("Spawn"))
                {
                    ((SquadBfSpawner)target).Spawn();
                }
            }
        }
#endif
    }
}