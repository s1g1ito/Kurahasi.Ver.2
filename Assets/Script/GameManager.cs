using System.Collections.Generic;
using UnityEngine;
using static TreeEditor.TreeEditorHelper;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int pickaxeDurability = 50; // 現在の耐久値
    public int maxPickaxeDurability = 50;     // 最大耐久値

    public bool jumpBoostPurchased = false; // ジャンプ強化を購入したか
    public int jumpBoostRemaining = 0;      // 残り強化ジャンプ回数

    // 掘られたタイルの座標を保存する
    public HashSet<Vector3Int> minedTiles = new HashSet<Vector3Int>();

    public Dictionary<OreType, int> oreCounts = new Dictionary<OreType, int>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーンをまたいでも破棄されない
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool IsPickaxeDurabilityMax()
    {
        return pickaxeDurability >= maxPickaxeDurability;
    }
    // 修理（最大まで回復）
    public void RepairPickaxe()
    {
        pickaxeDurability = maxPickaxeDurability;
    }
    public int GetOre(OreType type) 
    { 
        return oreCounts.ContainsKey(type) ? oreCounts[type] : 0; 
    }
    public void SetOre(OreType type, int amount) 
    { 
        oreCounts[type] = amount; 
    }

    // 耐久値を減らす
    public void ReduceDurability(int amount)
    {
        pickaxeDurability -= amount;
        pickaxeDurability = Mathf.Clamp(pickaxeDurability, 0, maxPickaxeDurability);
    }

    
}
