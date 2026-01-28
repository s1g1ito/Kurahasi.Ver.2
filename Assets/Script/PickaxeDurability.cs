using UnityEngine;
using UnityEngine.UI;

public class PickaxeDurability : MonoBehaviour
{
    private int maxDurability = 50;
    private int currentDurability;

    public Slider durabilitySlider;

    void Start()
    {
        // GameManager から耐久値を読み込む（シーンをまたいでも保持）
        currentDurability = GameManager.Instance.pickaxeDurability;

        // UI スライダーの初期設定
        if (durabilitySlider != null)
        {
            durabilitySlider.maxValue = maxDurability;
            durabilitySlider.value = currentDurability;
        }
    }

    public bool CanDig()
    {
        return currentDurability > 0;
    }

    public void Use(int amount)
    {
        currentDurability -= amount;
        currentDurability = Mathf.Clamp(currentDurability, 0, maxDurability);

        // GameManager に保存（シーン移動しても耐久値が残る）
        GameManager.Instance.pickaxeDurability = currentDurability;

        // UI 更新
        if (durabilitySlider != null)
        {
            durabilitySlider.value = currentDurability;
        }
    }
}
