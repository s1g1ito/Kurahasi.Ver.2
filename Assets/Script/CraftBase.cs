using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// クラフト・購入系の共通処理をまとめた基底クラス
/// </summary>
public abstract class CraftBase : MonoBehaviour
{
    [Header("必要素材（Inspectorで設定）")]
    public List<OreSlot> requiredOres = new List<OreSlot>();

    // ボタンから呼ばれる共通処理
    public void Craft()
    {
        var inv = PlayerInventory.Instance;

        // ① 素材チェック
        foreach (var ore in requiredOres)
        {
            if (!inv.HasEnough(ore.type, ore.amount))
            {
                Debug.Log("素材が足りません");
                return;
            }
        }

        // ② 素材消費
        foreach (var ore in requiredOres)
        {
            inv.UseOre(ore.type, ore.amount);
        }

        // ③ 成功時の処理（各クラスで定義）
        OnCraftSuccess();
    }

    /// <summary>
    /// クラフト成功時の処理（派生クラスで実装）
    /// </summary>
    protected abstract void OnCraftSuccess();
}
