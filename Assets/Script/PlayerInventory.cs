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
    }

    void Start()
    {
        // GameManager が確実に存在してから読み込む
        LoadFromGameManager();
    }


    void LoadFromGameManager()
    {
        foreach (var ore in oreDict)
        {
            ore.Value.amount = GameManager.Instance.GetOre(ore.Key);
        }
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
