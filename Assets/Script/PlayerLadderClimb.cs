using UnityEngine;

public class PlayerLadderClimb : MonoBehaviour
{
    // 梯子を登るスピード
    public float climbSpeed = 3f;

    // 梯子に触れているかどうか
    private bool isOnLadder = false;

    // プレイヤーの Rigidbody2D
    private Rigidbody2D rb;

    void Start()
    {
        // プレイヤーの Rigidbody2D を取得
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isOnLadder)
        {
            // 重力を無効化（落ちないようにする）
            rb.gravityScale = 0f;

            // Wキーで上昇
            if (Input.GetKey(KeyCode.W))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, climbSpeed);
            }
            else
            {
                // キーを離したら停止
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            }
        }
        else
        {
            // 梯子から離れたら重力を戻す
            rb.gravityScale = 1f;
        }
    }

    // 2D のトリガーに入ったとき
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isOnLadder = true;
        }
    }

    // 2D のトリガーから出たとき
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isOnLadder = false;
        }
    }
}
