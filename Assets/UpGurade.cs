using UnityEngine;

/// <summary>
/// ツルハシの最大耐久値を強化するクラフト
/// </summary>
public class UpGurade : CraftBase
{
    public PickaxeDurability pickaxe;

    [Header("強化後の最大耐久値")]
    public int newMaxDurability = 100;
    public void OnClickCraft()
    {
        Craft(); // CraftBase にある想定
    }

    /// <summary>
    /// クラフト成功時の処理
    /// （素材消費後に自動で呼ばれる）
    /// </summary>
    protected override void OnCraftSuccess()
    {
        var gm = GameManager.Instance;

        // 最大耐久値を更新
        gm.maxPickaxeDurability = newMaxDurability;
        gm.pickaxeDurability = newMaxDurability;

        // 実体のピッケルにも反映
        pickaxe.SetMaxDurability(newMaxDurability);

        Debug.Log($"ツルハシ強化成功！ 最大耐久値 {newMaxDurability}");
    }
}
