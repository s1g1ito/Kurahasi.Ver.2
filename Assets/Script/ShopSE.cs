using UnityEngine;

public class ShopSE : MonoBehaviour
{
    [SerializeField] private AudioClip clickSE; // 再生する効果音
    private AudioSource audioSource;

    void Awake()
    {
        // AudioSource を取得（なければ追加）
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
    }

    /// <summary>
    /// ボタンから呼び出す効果音再生
    /// </summary>
    public void PlayClickSound()
    {
        if (clickSE != null)
        {
            audioSource.PlayOneShot(clickSE);
        }
        else
        {
            Debug.LogWarning("clickSE が設定されていません。");
        }
    }
}
