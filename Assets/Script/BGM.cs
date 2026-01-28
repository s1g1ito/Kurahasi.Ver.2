using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour
{
    public Slider slider;
    AudioSource audioSource;

    private static BGM instance;

    public static float volume = 1f;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        audioSource.volume = volume;

        SetupSlider();
    }

    void SetupSlider()
    {
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            if (slider == null)
                slider = FindFirstObjectByType<Slider>();

            if (slider != null)
            {
                slider.value = volume;
                slider.onValueChanged.RemoveAllListeners();
                slider.onValueChanged.AddListener(OnVolumeChanged);
            }
        }
    }

    void OnVolumeChanged(float v)
    {
        volume = v;

        if (audioSource != null)
            audioSource.volume = v;
    }

    void OnSceneChanged(Scene prev, Scene next)
    {
        SetupSlider();

        if (audioSource != null)
            audioSource.volume = volume;
    }

    // SceneBBGM ‚©‚ç AudioSource ‚ðŽó‚¯Žæ‚é
    public void SetAudioSource(AudioSource src)
    {
        audioSource = src;
        audioSource.volume = volume;
    }
}






