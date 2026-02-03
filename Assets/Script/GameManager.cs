using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int pickaxeDurability = 50;
    public int maxDurability = 50;

    public bool jumpBoostPurchased = false;
    public int jumpBoostRemaining = 0;

    public HashSet<Vector3Int> minedTiles = new HashSet<Vector3Int>();

    public Dictionary<OreType, int> oreCounts = new Dictionary<OreType, int>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // š OreType ‚ğ‚·‚×‚Ä‰Šú‰»
            foreach (OreType type in System.Enum.GetValues(typeof(OreType)))
            {
                if (!oreCounts.ContainsKey(type))
                    oreCounts[type] = 0;
            }
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

    // š zÎ‚ğ‘‚â‚·
    public void AddOre(OreType type, int amount)
    {
        if (!oreCounts.ContainsKey(type))
            oreCounts[type] = 0;

        oreCounts[type] += amount;
    }

    // š zÎ‚ğÁ”ï‚·‚é
    public bool UseOre(OreType type, int amount)
    {
        if (GetOre(type) < amount)
            return false;

        oreCounts[type] -= amount;
        return true;
    }

    public void ReduceDurability(int amount)
    {
        pickaxeDurability -= amount;
        pickaxeDurability = Mathf.Clamp(pickaxeDurability, 0, maxDurability);
    }
}
