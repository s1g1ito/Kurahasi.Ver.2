using UnityEngine;
using UnityEngine.UI;

public class PickaxeDurability : MonoBehaviour
{
    // ツルハシの最大耐久値
    private int maxDurability = 50;
    // 現在の耐久値（ゲーム開始時に maxDurability で初期化される）
    private int currentDurability;
    // 耐久値を表示する UI スライダー
    public Slider durabilitySlider;

    void Start()
    {
        maxDurability = GameManager.Instance.maxPickaxeDurability;
        currentDurability = GameManager.Instance.pickaxeDurability;
        //LoadDurability();
        Debug.Log("Start時の currentDurability = " + currentDurability);
        // UI スライダーの初期設定
        if (durabilitySlider != null)
        {
            durabilitySlider.maxValue = maxDurability;
            durabilitySlider.value = currentDurability;
        }
    }
    // 掘ることができるかどうかを返す（耐久値が 0 より大きいか）
    public bool CanDig()
    {
        return currentDurability > 0;
    }
    // ツルハシを使用したときに耐久値を減らす処理
    public void Use(int amount)
    {
        // 指定された量だけ耐久値を減らす
        currentDurability -= amount;
        // 耐久値が 0から最大値の範囲を超えないように調整
        currentDurability = Mathf.Clamp(currentDurability, 0, maxDurability);

        // GameManager に保存（シーン移動しても耐久値が残る）
        GameManager.Instance.pickaxeDurability = currentDurability;

        // スライダーが設定されている場合は UI に反映
        if (durabilitySlider != null)
        {
            durabilitySlider.value = currentDurability;
        }
    }
    // ツルハシの最大耐久値を設定するメソッド
    public void SetMaxDurability(int newMax)
    {
        maxDurability = newMax;
        currentDurability = newMax;
        if (durabilitySlider != null)
        {
            durabilitySlider.maxValue = newMax;
            durabilitySlider.value = newMax;
        }
    }
}
