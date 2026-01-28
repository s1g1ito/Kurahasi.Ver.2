using UnityEngine;

public class PickaxeRepairButton : MonoBehaviour
{
    public int maxDurability = 50;      // ピッケルの最大耐久値

    public void OnRepairButtonPressed()
    {
        int current = GameManager.Instance.pickaxeDurability;

        //すでに耐久値が最大
        if (current >= maxDurability)
        {
            Debug.Log("耐久値はすでに最大です");
            return;
        }

        var inv = PlayerInventory.Instance;

        // 必要な素材
        int needCoal = 2;

        // 足りてるかチェック
        if(!inv.HasEnough(OreType.Coal, needCoal))
        {
            Debug.Log("素材が足りません");
            return;
        }

        // 素材を消費
        inv.UseOre(OreType.Coal, needCoal);

        //耐久値を最大に
        GameManager.Instance.pickaxeDurability = maxDurability;

        Debug.Log("ピッケルを修理しました！");
    }
}
