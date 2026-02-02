using UnityEngine;

public class ShopUIManager : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    // すべてのパネルを非表示にする
    void HideAll()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
    }

    // EnhancementPanel のボタン → Panel1 を表示
    public void ShowPanel1()
    {
        HideAll();
        panel1.SetActive(true);
    }

    // Panel1 のボタン(1) → Panel2 を表示
    public void ShowPanel2()
    {
        HideAll();
        panel2.SetActive(true);
    }

    // Panel1 のボタン(2) → Panel3 を表示
    public void ShowPanel3()
    {
        HideAll();
        panel3.SetActive(true);
    }
}
