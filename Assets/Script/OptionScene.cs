using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
 

    // OptionScene Å® StartScene Ç…ñﬂÇÈ
    public void GoToStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}

