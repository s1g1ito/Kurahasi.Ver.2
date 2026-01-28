using UnityEngine;

public class BuyJumpBootsButton : MonoBehaviour
{
    public PlayerInventory inventory;   // PlayerInventory を Inspector でセット
    public int requiredEmerald = 5;     // 必要なエメラルド数

    public void OnBuyButtonPressed()
    {
        //エメラルドが5個あるかチェック
        if (!inventory.HasEnough(OreType.Emerald, requiredEmerald))
        {
            Debug.Log("素材が足りません！");
            return;
        }

        //エメラルドを5個消費
        inventory.UseOre(OreType.Emerald, requiredEmerald);

        //靴を購入（ここに強化処理を書く）
        Debug.Log("ジャンプ強化の靴を購入しました！");

        // 例：プレイヤーのジャンプ力を上げる処理
        // player.jumpPower += 2;
    }
}
