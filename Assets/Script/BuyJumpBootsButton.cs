using UnityEngine;

public class BuyJumpBootsButton : CraftBase
{
    protected override void OnCraftSuccess()
    {
        var gm = GameManager.Instance;

        gm.jumpBoostPurchased = true;
        gm.jumpBoostRemaining = 5;

        Debug.Log("ƒWƒƒƒ“ƒv‹­‰»‚ÌŒC‚ğw“ü‚µ‚Ü‚µ‚½I");
    }
}
