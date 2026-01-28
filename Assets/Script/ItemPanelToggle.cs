using UnityEngine;

public class ItemPanelToggle : MonoBehaviour
{
    public GameObject itempanel;

    private void Start()
    {
        itempanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            itempanel.SetActive(!itempanel.activeSelf);
        }
    }
}
