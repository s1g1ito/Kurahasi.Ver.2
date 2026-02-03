using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // プレイヤーの移動速度
    public float moveSpeed = 5f;

    // 通常ジャンプ力
    public float jumpForce = 7f;

    // 強化ジャンプ力
    public float boostedJumpForce = 12f;

    // 地面判定を行う位置
    public Transform groundCheck;

    // 地面判定の円の大きさ
    public float groundCheckRadius = 0.2f;

    // どのレイヤーを「地面」として判定するか
    public LayerMask groundLayer;

    private Rigidbody2D rb;

    // ゴール穴などに吸い込まれているかどうか
    public bool isAbsorbing = false;

    // 現在地面にいるかどうか
    [SerializeField] private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 地面判定
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // 吸い込み中なら操作不可
        if (isAbsorbing)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            return;
        }

        // 左右移動
        float move = 0f;

        if (Input.GetKey(KeyCode.A))
            move = -1f;
        if (Input.GetKey(KeyCode.D))
            move = 1f;

        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        // ============================
        // ジャンプ（強化ジャンプ対応）
        // ============================
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            float finalJumpPower = jumpForce;

            //ジャンプ強化が有効なら強化ジャンプ
            if (GameManager.Instance.jumpBoostPurchased &&
                GameManager.Instance.jumpBoostRemaining > 0)
            {
                finalJumpPower = boostedJumpForce;

                // 使用回数を減らす
                GameManager.Instance.jumpBoostRemaining--;

                Debug.Log("強化ジャンプ！ 残り：" + GameManager.Instance.jumpBoostRemaining);

                // 0になったら強化終了
                if (GameManager.Instance.jumpBoostRemaining <= 0)
                {
                    GameManager.Instance.jumpBoostPurchased = false;
                    Debug.Log("強化ジャンプ終了。通常ジャンプに戻ります。");
                }
            }

            // 実際のジャンプ
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, finalJumpPower);
        }
    }
}
