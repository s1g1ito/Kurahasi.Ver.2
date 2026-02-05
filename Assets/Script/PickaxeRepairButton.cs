using UnityEngine;

public class PickaxeRepairButton : CraftBase
{
    public void OnClickCraft()
    {
        Craft(); // CraftBase にある想定
    }

    protected override void OnCraftSuccess()
    {
        var gm = GameManager.Instance;

        if (gm.IsPickaxeDurabilityMax())
        {
            Debug.Log("耐久値はすでに最大です");
            return;
        }

        gm.RepairPickaxe();
        Debug.Log("ピッケルを修理しました！");
    }
}