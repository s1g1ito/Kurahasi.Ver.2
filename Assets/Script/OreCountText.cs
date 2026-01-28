using UnityEngine;
using UnityEngine.UI;

public class OreCountText : MonoBehaviour
{
    public OreType oreType;
    public Text CountText;

    private PlayerInventory inventory;

    void Start()
    {
        // CountText が設定されていない場合はエラー
        if (CountText == null)
        {
            Debug.LogError("OreCountText: CountText が Inspector に設定されていません");
            return;
        }

        // PlayerInventory を探す
        inventory = FindFirstObjectByType<PlayerInventory>();

        if (inventory == null)
        {
            Debug.LogError("OreCountText: PlayerInventory がシーンに見つかりません");
            return;
        }

        // イベント登録
        inventory.onOreChanged += UpdateText;

        // 初期表示
        UpdateText();
    }

    void UpdateText()
    {
        if (inventory == null || CountText == null)
            return;

        int count = inventory.GetOre(oreType);
        CountText.text = "×" + count;
    }
}
