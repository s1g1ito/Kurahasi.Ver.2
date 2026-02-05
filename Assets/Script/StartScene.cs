using UnityEngine;
using UnityEngine.SceneManagement;


public class StartScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // StartScene Å® OptionScene Ç…êÿÇËë÷Ç¶ÇÈ
    public void GoToOptionScene()
    {
        SceneManager.LoadScene("OptionScene");
    }

    
}
