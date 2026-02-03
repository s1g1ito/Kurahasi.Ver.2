using UnityEngine;

public class UpGurade : MonoBehaviour
{
    public PickaxeDurability pickaxe;

    public void Craft()
    {
        var inv = PlayerInventory.Instance; 
        // 必要素材
        int needCopper = 4;
        int needIron = 2; 
        // 足りているかチェック
        if (!inv.HasEnough(OreType.Copper, needCopper) ||
            !inv.HasEnough(OreType.Iron, needIron)) 
        {
            Debug.Log("素材が足りません"); 
            return;
        } 
        // 素材を消費
        inv.UseOre(OreType.Copper, needCopper);
        inv.UseOre(OreType.Iron, needIron); 
        Debug.Log("クラフト成功！ Copper4 と Iron2 を消費しました");
        // ★ 最大耐久値を 70 にアップ
        // ★ GameManager にも保存する
        GameManager.Instance.maxPickaxeDurability = 70;
        GameManager.Instance.pickaxeDurability = 70;
        pickaxe.SetMaxDurability(70); 
        Debug.Log("ツルハシの最大耐久値が 70 にアップしました！");
    }
}
