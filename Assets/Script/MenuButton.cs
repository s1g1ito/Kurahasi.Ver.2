using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    
    public GameObject EnhancementPanel;
    public PlayerMovement playerMovement;
    // Create, Enhancement, Backの各ボタンに対応するメソッド

    void Start()
    {
        EnhancementPanel.SetActive(false);
    }

    public void OnEnhancement()
    {
        bool isActive = EnhancementPanel.activeSelf;
        EnhancementPanel.SetActive(!isActive);
        if (playerMovement != null)
        {
            playerMovement.isAbsorbing = !isActive;
        }
    }



    public void OnBack()
    {
        if(playerMovement != null)
        SceneManager.LoadScene("GameScene");
        
    }


}
