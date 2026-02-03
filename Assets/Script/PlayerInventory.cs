using UnityEngine;
using System;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;

    [Header("鉱石所持数（Inspectorで編集）")]
    public List<OreSlot> ores = new List<OreSlot>();
    Dictionary<OreType, OreSlot> oreDict = new Dictionary<OreType, OreSlot>();
    public Action onOreChanged;

    void Awake()
    {
        Instance = this;

        oreDict.Clear();
        foreach (var ore in ores)
        {
            oreDict[ore.type] = ore;
        }

        //GameManager がまだ存在しない場合は何もしない
        if (GameManager.Instance == null)
        {
            Debug.LogWarning("PlayerInventory: GameManager がまだ存在しません。Start で読み込みます。");
            return;
        }

        InitializeOreFromGameManager();
    }


    // 鉱石の所持数を正しく復元するための処理
    void InitializeOreFromGameManager()
    {
        foreach (var ore in oreDict)
        {
            ore.Value.amount = GameManager.Instance.GetOre(ore.Key);
        }
    }


    void Start()
    {
        if (GameManager.Instance != null)
        {
            InitializeOreFromGameManager();
        }
    }


    // ★ シーンに戻ってきたときにも呼べるように public にする
    public void LoadFromGameManager()
    {
        foreach (var ore in oreDict)
        {
            ore.Value.amount = GameManager.Instance.GetOre(ore.Key);
        }

        onOreChanged?.Invoke();
    }

    public int GetOre(OreType type)
    {
        return oreDict.ContainsKey(type) ? oreDict[type].amount : 0;
    }

    public void AddOre(OreType type, int amount)
    {
        if (!oreDict.ContainsKey(type)) return;

        oreDict[type].amount += amount;

        // GameManager に保存
        GameManager.Instance.SetOre(type, oreDict[type].amount);

        onOreChanged?.Invoke();
    }

    public bool UseOre(OreType type, int amount)
    {
        if (!HasEnough(type, amount)) return false;

        oreDict[type].amount -= amount;

        // GameManager に保存
        GameManager.Instance.SetOre(type, oreDict[type].amount);

        onOreChanged?.Invoke();
        return true;
    }

    public bool HasEnough(OreType type, int amount)
    {
        return GetOre(type) >= amount;
    }
}
