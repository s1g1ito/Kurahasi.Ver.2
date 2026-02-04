using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム全体の状態を管理するクラス
/// ・シーンをまたいで保持したいデータをすべて管理する
/// ・Singleton + DontDestroyOnLoad で常に1つだけ存在する
/// </summary>
public class GameManager : MonoBehaviour
{
    /* ===============================
     * Singleton
     * =============================== */

    // どこからでも参照できる唯一のインスタンス
    public static GameManager Instance;

    /* ===============================
     * つるはし関連
     * =============================== */

    // 現在のつるはし耐久値
    public int pickaxeDurability = 50;

    // つるはしの最大耐久値
    public int maxPickaxeDurability = 50;

    /* ===============================
     * 強化・購入状態
     * =============================== */

    // ジャンプ強化を購入済みかどうか
    public bool jumpBoostPurchased = false;

    // 残りジャンプ強化回数
    public int jumpBoostRemaining = 0;

    /* ===============================
     * ワールド状態
     * =============================== */

    // すでに掘られたタイルの座標を記録
    // 同じタイルを再生成しないために使う
    public HashSet<Vector3Int> minedTiles = new HashSet<Vector3Int>();

    /* ===============================
     * インベントリ保存用
     * =============================== */

    // 鉱石の所持数を保存する辞書
    // PlayerInventory はここから読み書きする
    public Dictionary<OreType, int> oreCounts = new Dictionary<OreType, int>();

    /* ===============================
     * 初期化
     * =============================== */

    void Awake()
    {
        // Singleton の確立
        if (Instance == null)
        {
            Instance = this;

            // シーンをまたいでも破棄されないようにする
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // すでに存在している場合は破棄
            Destroy(gameObject);
        }
    }

    /* ===============================
     * つるはし耐久処理
     * =============================== */

    /// <summary>
    /// つるはしの耐久値が最大かどうかを判定
    /// </summary>
    public bool IsPickaxeDurabilityMax()
    {
        return pickaxeDurability >= maxPickaxeDurability;
    }

    /// <summary>
    /// つるはしを最大耐久まで修理する
    /// </summary>
    public void RepairPickaxe()
    {
        pickaxeDurability = maxPickaxeDurability;
    }

    /// <summary>
    /// つるはしの耐久値を減らす
    /// 0～最大値の範囲に収める
    /// </summary>
    public void ReduceDurability(int amount)
    {
        pickaxeDurability -= amount;
        pickaxeDurability = Mathf.Clamp(
            pickaxeDurability,
            0,
            maxPickaxeDurability
        );
    }

    /* ===============================
     * 鉱石データの保存・取得
     * =============================== */

    /// <summary>
    /// 指定した鉱石の所持数を取得する
    /// </summary>
    public int GetOre(OreType type)
    {
        return oreCounts.ContainsKey(type)
            ? oreCounts[type]
            : 0;
    }

    /// <summary>
    /// 指定した鉱石の所持数を保存する
    /// </summary>
    public void SetOre(OreType type, int amount)
    {
        oreCounts[type] = amount;
    }
}
