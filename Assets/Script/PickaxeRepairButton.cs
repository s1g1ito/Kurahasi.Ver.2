using UnityEngine;

public class PickaxeRepairButton : MonoBehaviour
{
        // 必要な素材
         public int needCoal = 2;

    // 足りてるかチェック
    public void OnRepairButtonPressed()
    {
        var gm = GameManager.Instance;
        var inv = PlayerInventory.Instance;

        // すでに最大
        if (gm.IsPickaxeDurabilityMax())
        {
            Debug.Log("耐久値はすでに最大です");
            return;
        }

        // 素材チェック
        if (!inv.HasEnough(OreType.Coal, needCoal))
        {
            Debug.Log("素材が足りません");
            return;
        }

        // 消費
        inv.UseOre(OreType.Coal, needCoal);

        // 修理
        gm.RepairPickaxe();

        Debug.Log("ピッケルを修理しました！");
    }
}

