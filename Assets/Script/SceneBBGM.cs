using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBBGM : MonoBehaviour
{
    public static SceneBBGM instance;

    public AudioSource A_BGM; // StartScene óp
    public AudioSource B_BGM; // GameScene óp

    private string beforeScene;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            if (A_BGM != null) DontDestroyOnLoad(A_BGM.gameObject);
            if (B_BGM != null) DontDestroyOnLoad(B_BGM.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }

    void Start()
    {
        beforeScene = "StartScene";

        if (B_BGM != null) B_BGM.Stop();
        if (A_BGM != null) A_BGM.Play();

        // BGM.cs Ç… A_BGM ÇìnÇ∑
        var bgm = FindFirstObjectByType<BGM>();
        if (bgm != null) bgm.SetAudioSource(A_BGM);

        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        var bgm = FindFirstObjectByType<BGM>();

        // StartScene Å® GameScene
        if (beforeScene == "StartScene" && nextScene.name == "GameScene")
        {
            if (A_BGM != null) A_BGM.Stop();
            if (B_BGM != null) B_BGM.Play();

            if (bgm != null) bgm.SetAudioSource(B_BGM);
        }

        // GameScene Å® StartScene
        if (beforeScene == "GameScene" && nextScene.name == "StartScene")
        {
            if (B_BGM != null) B_BGM.Stop();
            if (A_BGM != null) A_BGM.Play();

            if (bgm != null) bgm.SetAudioSource(A_BGM);
        }

        beforeScene = nextScene.name;
    }
}
