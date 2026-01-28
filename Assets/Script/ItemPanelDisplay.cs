using UnityEngine;

public class ItemPanelDisplay : MonoBehaviour
{
    [SerializeField] GameObject itemPanel; // ItemPanel参照
    [SerializeField] MonoBehaviour PlayerMovement;  // Player参照

    void Start()
    {
        itemPanel.SetActive(false); // ItemPanelを非表示
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            
            Toggle();
            Debug.Log("タブキーが押された");
        }
    }

    public void Toggle()
    {
        bool isActive = itemPanel.activeSelf;
        itemPanel.SetActive(!itemPanel.activeSelf);
        PlayerMovement.enabled = isActive;
    }

    public void Close()
    {
        itemPanel.SetActive(false);
        PlayerMovement.enabled = true;
    }
}
