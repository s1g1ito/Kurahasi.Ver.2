using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // プレイヤーの移動速度
    public float moveSpeed = 5f;

    // ジャンプの強さ
    public float jumpForce = 7f;

    // 地面判定を行う位置
    public Transform groundCheck;

    // 地面判定の円の大きさ
    public float groundCheckRadius = 0.2f;

    // どのレイヤーを「地面」として判定するか
    public LayerMask groundLayer;     

    private Rigidbody2D rb;

    // ゴール穴などに吸い込まれているかどうか
    // true のときはプレイヤーを操作できない
    public bool isAbsorbing = false;

    // 現在地面にいるかどうか（Inspector で確認できるように SerializeField）
    [SerializeField] private bool isGrounded = false;

    void Start()
    {
        // プレイヤーに付いている Rigidbody2D を取得
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 地面判定（Raycast）
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // 左右移動
        float move = 0f;

        if (Input.GetKey(KeyCode.A))
            move = -1f;
        if (Input.GetKey(KeyCode.D))
            move = 1f;

        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        // ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // =====================
        // 吸い込み中の処理
        // =====================

        // ゴール穴などに吸い込まれている場合
        if (isAbsorbing)
        {
            // プレイヤーを完全に止める
            rb.linearVelocity = Vector2.zero;

            // 回転もしないようにする
            rb.angularVelocity = 0f;

            // これより下の処理は実行しない
            return;
        }
    }
}
