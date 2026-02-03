using System.Collections.Generic;
using UnityEngine;
using static TreeEditor.TreeEditorHelper;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int pickaxeDurability = 50; // Œ»İ‚Ì‘Ï‹v’l
    public int maxPickaxeDurability = 50;     // Å‘å‘Ï‹v’l

    public bool jumpBoostPurchased = false;
    public int jumpBoostRemaining = 0;

    // Œ@‚ç‚ê‚½ƒ^ƒCƒ‹‚ÌÀ•W‚ğ•Û‘¶‚·‚é
    public HashSet<Vector3Int> minedTiles = new HashSet<Vector3Int>();

    public Dictionary<OreType, int> oreCounts = new Dictionary<OreType, int>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ƒV[ƒ“‚ğ‚Ü‚½‚¢‚Å‚à”jŠü‚³‚ê‚È‚¢
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

    // ‘Ï‹v’l‚ğŒ¸‚ç‚·
    public void ReduceDurability(int amount)
    {
        pickaxeDurability -= amount;
        pickaxeDurability = Mathf.Clamp(pickaxeDurability, 0, maxPickaxeDurability);
    }

    
}
