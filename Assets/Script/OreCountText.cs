using UnityEngine;
using UnityEngine.UI;

public class OreCountText : MonoBehaviour
{
    public OreType oreType;
    public Text CountText;

    private PlayerInventory inventory;

    void OnEnable()
    {
        // ƒV[ƒ“•œ‹A‚É‚à PlayerInventory ‚ğ’T‚µ’¼‚·
        TryRegister();
    }

    void OnDisable()
    {
        // ƒCƒxƒ“ƒg‰ğœid•¡“o˜^–h~j
        if (inventory != null)
            inventory.onOreChanged -= UpdateText;
    }

    void Start()
    {
        TryRegister();
    }

    // š PlayerInventory ‚ğ’T‚µ‚ÄƒCƒxƒ“ƒg“o˜^‚·‚é‹¤’ÊŠÖ”
    void TryRegister()
    {
        if (CountText == null)
        {
            Debug.LogError("OreCountText: CountText ‚ª Inspector ‚Éİ’è‚³‚ê‚Ä‚¢‚Ü‚¹‚ñ");
            return;
        }

        // ‚·‚Å‚É“o˜^Ï‚İ‚È‚ç‰½‚à‚µ‚È‚¢
        if (inventory != null)
            return;

        inventory = FindFirstObjectByType<PlayerInventory>();

        if (inventory == null)
        {
            Debug.LogWarning("OreCountText: PlayerInventory ‚ª‚Ü‚¾Œ©‚Â‚©‚è‚Ü‚¹‚ñ");
            return;
        }

        // ƒCƒxƒ“ƒg“o˜^
        inventory.onOreChanged += UpdateText;

        // ‰Šú•\¦
        UpdateText();
    }

    void UpdateText()
    {
        if (inventory == null || CountText == null)
            return;

        int count = inventory.GetOre(oreType);
        CountText.text = "~" + count;
    }
}
