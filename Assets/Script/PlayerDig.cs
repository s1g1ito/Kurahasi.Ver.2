using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerDig : MonoBehaviour
{
    private float digRange = 3.0f;     // 掘れる距離
    public LayerMask digLayer;        // GroundLayer + StoneLayer

    private int digCost = 1; // 掘るたびに減る耐久値

    public PlayerInventory inventory;
    private PickaxeDurability durability;

    [System.Serializable]
    public class DigTilemapData
    {
        public Tilemap tilemap;
        public OreType oreType; // Noneなら何も獲得しない
    }

    public DigTilemapData[] digTilemaps;

    void Start()
    {
        durability = GetComponent<PickaxeDurability>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 左クリックで掘る
        {
            TryDig();
        }
    }

    void TryDig()
    {
        Debug.Log("durability = " + durability);

        Debug.Log("Camera.main = " + Camera.main);


        // 耐久値チェック
        if (!durability.CanDig())
        {
            Debug.Log("耐久値がないため掘れません");
            return;
        }

        // マウス位置をワールド座標に変換
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;

        // 掘れる距離外
        if (Vector3.Distance(transform.position, mouseWorldPos) > digRange)
            return;

        // Raycast でタイルに当たったか確認
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero, 0.1f, digLayer);

        if (hit.collider == null)
            return;

        foreach (var data in digTilemaps)
        {
            Vector3Int cellPos = data.tilemap.WorldToCell(mouseWorldPos);

            if (data.tilemap.HasTile(cellPos))
            {
                // タイル破壊
                data.tilemap.SetTile(cellPos, null);

                // 報酬
                if (data.oreType != OreType.None)
                {
                    inventory.AddOre(data.oreType, 1);
                }

                // 耐久消費
                durability.Use(digCost);

                return; // 1回の掘りで1タイル
            }
        }
    }
}