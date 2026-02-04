using UnityEngine;
using System.Collections.Generic;

public class UpGurade : MonoBehaviour
{
    public PickaxeDurability pickaxe;

    [Header("•K—v‘fŞiInspector‚Å•ÏX‰Â”\j")]
    public List<OreSlot> requiredOres = new List<OreSlot>();

    [Header("‹­‰»Œã‚ÌÅ‘å‘Ï‹v’l")]
    public int newMaxDurability = 100;

    public void Craft()
    {
        var inv = PlayerInventory.Instance;

        // ‡@ ‘fŞƒ`ƒFƒbƒN
        foreach (var cost in requiredOres)
        {
            if (!inv.HasEnough(cost.type, cost.amount))
            {
                Debug.Log("‘fŞ‚ª‘«‚è‚Ü‚¹‚ñ");
                return;
            }
        }

        // ‡A ‘fŞÁ”ï
        foreach (var cost in requiredOres)
        {
            inv.UseOre(cost.type, cost.amount);
        }

        // ‡B ‹­‰»”½‰f
        GameManager.Instance.maxPickaxeDurability = newMaxDurability;
        GameManager.Instance.pickaxeDurability = newMaxDurability;
        pickaxe.SetMaxDurability(newMaxDurability);

        Debug.Log($"ƒcƒ‹ƒnƒV‹­‰»¬Œ÷I Å‘å‘Ï‹v’l {newMaxDurability}");
    }
}
