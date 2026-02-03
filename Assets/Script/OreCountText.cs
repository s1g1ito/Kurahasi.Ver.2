using UnityEngine;
using UnityEngine.UI;

public class OreCountText : MonoBehaviour
{
    public OreType oreType;
    public Text CountText;

    private PlayerInventory inventory;

    void OnEnable()
    { // シーン内の PlayerInventory を探す
        inventory = FindFirstObjectByType<PlayerInventory>();
        if (inventory == null)
        {
            Debug.LogError("PlayerInventory がシーンに見つかりません");
            return;
        }
        // イベント登録
        inventory.onOreChanged += UpdateText;
        // 初期表示
        UpdateText();
    }

    // ★ PlayerInventory を探してイベント登録する共通関数
   
    void OnDisable()
    {
        // イベント解除（重複登録防止）
        if (inventory != null)
            inventory.onOreChanged -= UpdateText;
    }

    void UpdateText()
    {
        if (inventory == null || CountText == null)
            return;

        int count = inventory.GetOre(oreType);
        CountText.text = "×" + count;
    }
}
