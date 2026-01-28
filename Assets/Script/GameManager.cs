using System.Collections.Generic;
using UnityEngine;
using static TreeEditor.TreeEditorHelper;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int pickaxeDurability = 50; // 現在の耐久値
    public int maxDurability = 50;     // 最大耐久値

    //public int coalCount = 0;          // 石炭の所持数

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
        pickaxeDurability = Mathf.Clamp(pickaxeDurability, 0, maxDurability);
    }

    //// ピッケルを修理する（Coal 2個必要）
    //public bool TryRepairPickaxe()
    //{
    //    // すでに最大なら修理不要
    //    if (pickaxeDurability >= maxDurability)
    //    {
    //        Debug.Log("耐久値はすでに最大です");
    //        return false;
    //    }

    //    // Coal が足りない
    //    if (coalCount < 2)
    //    {
    //        Debug.Log("アイテムが足りません！");
    //        return false;
    //    }

    //    // Coal を消費して修理
    //    coalCount -= 2;
    //    pickaxeDurability = maxDurability;

    //    Debug.Log("ピッケルを修理しました！");
    //    return true;
    //}
}
