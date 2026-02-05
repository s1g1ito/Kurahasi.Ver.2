using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// プレイヤーのインベントリ管理クラス
/// ・鉱石の所持数を管理する
/// ・増減処理をまとめる
/// ・UIに変更通知を送る
/// ・シーン開始時に GameManager から所持数を復元する
/// </summary>
public class PlayerInventory : MonoBehaviour
{
    /* ===============================
     * Inspector 設定
     * =============================== */

    [Header("鉱石所持数（Inspectorで編集）")]
    // 鉱石の種類と初期所持数を Inspector で設定するためのリスト
    public List<OreSlot> ores = new List<OreSlot>();

    /* ===============================
     * 内部管理用データ
     * =============================== */

    // 鉱石を種類で高速に参照するための辞書
    Dictionary<OreType, OreSlot> oreDict = new Dictionary<OreType, OreSlot>();

    // 鉱石数が変わったときに UI へ通知するイベント
    public Action onOreChanged;

    // シーン内で唯一の PlayerInventory インスタンス
    public static PlayerInventory Instance;

    /* ===============================
     * 初期化処理
     * =============================== */

    void Awake()
    {
        // すでに存在していたら破棄（増殖防止）
        if (Instance != null )
        {
            Destroy(gameObject);
            return;
        }

        // Singleton 登録
        Instance = this;

        // Inspector の List → Dictionary に変換
        oreDict.Clear();
        foreach (var ore in ores)
        {
            oreDict[ore.type] = ore;
        }
    }


    void Start()
    {
        // GameManager が存在しない場合は何もしない
        // （Awake の呼ばれる順番対策）
        if (GameManager.Instance == null)
        {
            Debug.LogWarning(
                "PlayerInventory: GameManager がまだ存在しません。"
            );
            return;
        }

        // GameManager に保存されている所持数を読み込む
        LoadFromGameManager();
    }

    /* ===============================
     * GameManager 連携
     * =============================== */

    /// <summary>
    /// GameManager に保存されている鉱石所持数を
    /// PlayerInventory に反映する
    /// （シーン開始時・戻ってきた時に使用）
    /// </summary>
    public void LoadFromGameManager()
    {
        foreach (var ore in oreDict)
        {
            ore.Value.amount =
                GameManager.Instance.GetOre(ore.Key);
        }

        // UI 更新通知
        onOreChanged?.Invoke();
    }

    /* ===============================
     * 外部から使う API
     * =============================== */

    /// <summary>
    /// 指定した鉱石の現在の所持数を返す
    /// </summary>
    public int GetOre(OreType type)
    {
        return oreDict.ContainsKey(type)
            ? oreDict[type].amount
            : 0;
    }

    /// <summary>
    /// 指定した鉱石を必要数持っているか
    /// （クラフト・修理の判定用）
    /// </summary>
    public bool HasEnough(OreType type, int amount)
    {
        return GetOre(type) >= amount;
    }

    /// <summary>
    /// 鉱石を増やす処理
    /// </summary>
    public void AddOre(OreType type, int amount)
    {
        // 未登録の鉱石なら何もしない
        if (!oreDict.ContainsKey(type)) return;

        oreDict[type].amount += amount;

        //GameManagerに保存
        GameManager.Instance.SetOre(type, oreDict[type].amount);

        // UI 更新通知
        onOreChanged?.Invoke();
    }

    /// <summary>
    /// 鉱石を消費する処理
    /// 足りない場合は false を返す
    /// </summary>
    public bool UseOre(OreType type, int amount)
    {
        // 所持数が足りない場合は失敗
        if (!HasEnough(type, amount)) return false;

        oreDict[type].amount -= amount;

        //GameManagerに保存
        GameManager.Instance.SetOre(type, oreDict[type].amount);

        // UI 更新通知
        onOreChanged?.Invoke();
        return true;
    }
}
