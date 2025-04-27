using UnityEngine;

public class S4Player : MonoBehaviour
{
    private float moveSpeed = 3f;
    private float jumpPower = 5f;
    private Rigidbody2D rb;
    private bool isGrounded = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Moving();
        Jump();
        RopeCatch();
    }

    private void Moving()
    {
        Vector2 moveVelocity = Vector2.zero;
        float inputX = Input.GetAxisRaw("Horizontal");

        if (inputX < 0)
        {
            moveVelocity = Vector2.left;
            transform.localScale = new Vector2(1, 1);
        }
        else if (inputX > 0)
        {
            moveVelocity = Vector2.right;
            transform.localScale = new Vector2(-1, 1);
        }
        rb.linearVelocity = new Vector2(moveVelocity.x * moveSpeed, rb.linearVelocity.y);

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Rope"))
        {

        }
    }

    private void RopeCatch()
    {
        
    }
}
