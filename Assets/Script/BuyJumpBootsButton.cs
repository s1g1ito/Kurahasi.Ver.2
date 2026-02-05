using UnityEngine;

public class BuyJumpBootsButton : CraftBase
{
    public void OnClickCraft()
    {
        Craft(); // CraftBase にある想定
    }

    protected override void OnCraftSuccess()
    {
        var gm = GameManager.Instance;

        gm.jumpBoostPurchased = true;
        gm.jumpBoostRemaining = 5;

        Debug.Log("ジャンプ強化の靴を購入しました！");
    }
}
