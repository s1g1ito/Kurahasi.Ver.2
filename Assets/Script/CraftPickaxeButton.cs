using UnityEngine;
using UnityEngine.UI;

// ボタンを押すとツルハシを作るスクリプト
public class CraftPickaxeButton : MonoBehaviour
{
    public PlayerInventory playerInventory; // プレイヤーのインベントリ
    public Button craftButton;              // UIボタン

    // 必要な材料
    private int requiredIron = 6;
    private int requiredCoal = 9;

    void Start()
    {
        // ボタン押したときの処理を登録
        craftButton.onClick.AddListener(OnCraftButtonPressed);
    }

    void OnCraftButtonPressed()
    {
        // 鉄と石炭が必要数あるかチェック
        if (playerInventory.GetOre(OreType.Iron) >= requiredIron &&
            playerInventory.GetOre(OreType.Coal) >= requiredCoal)
        {
            // 材料を減らす
            playerInventory.UseOre(OreType.Iron, requiredIron);
            playerInventory.UseOre(OreType.Coal, requiredCoal);

            

            Debug.Log("ツルハシを作成しました！");
        }
        else
        {
            Debug.Log("材料が足りません！");
        }
    }
}
