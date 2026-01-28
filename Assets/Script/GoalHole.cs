using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalHole : MonoBehaviour
{
    private float moveSpeed = 2.5f; // 吸い込まれる速度
    private float scaleSpeed = 2.5f; // 縮む速度
    public string ShopScene;

    Transform player;
    bool playerInside = false; // プレイヤーが穴の中にいるかどうか
    bool absorbing = false; // 吸い込み中かどうか
    bool sceneChanged = false; // シーン変更済みかどうか

    void Update()
    {
        // Fキーで吸い込み開始
        if (playerInside && !absorbing && Input.GetKeyDown(KeyCode.F))
        {
            var move = player.GetComponent<PlayerMovement>();
            if(move != null)
            {
                move.isAbsorbing = true; // プレイヤーの移動を停止
            }
            absorbing = true;
            // 速度をゼロにする
            var rb = player.GetComponent<Rigidbody2D>();
            if (rb) rb.linearVelocity = Vector2.zero;
        }

        // // 吸い込み処理
        if (!absorbing || sceneChanged) return;
        {
            // 穴の中心に向かって移動
            player.position = Vector3.MoveTowards(
                player.position,
                transform.position,
                Time.deltaTime * moveSpeed
            );

            // 縮小処理
            player.localScale = Vector3.Lerp(
                player.localScale,
                Vector3.zero,
                Time.deltaTime * scaleSpeed
            );
            Debug.Log("吸い込み中");
        }
        // シーン切り替え判定
        if (player.localScale.x <= 0.02f)
        {
            sceneChanged = true;
            SceneManager.LoadScene(ShopScene);
            Debug.Log("シーン切り替え完了");
        }
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerInside = true;
            player = col.transform;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
}
