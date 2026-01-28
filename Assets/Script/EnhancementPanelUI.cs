using UnityEngine;
using UnityEngine.UI;

public class EnhancementPanelUI : MonoBehaviour
{
    public Text oreText;

    // âºÇÃïKóvêî
    int ironOre = 10;
    int goldOre = 5;

    void OnEnable()
    {
        UpdateOreText();
    }

    void UpdateOreText()
    {
        oreText.text =
            $" Å~{ironOre}\n" +
            $" Å~{goldOre}";
    }
}
