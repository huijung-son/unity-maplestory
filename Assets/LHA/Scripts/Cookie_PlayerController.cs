using UnityEngine;

public class Cookie_PlayerController : MonoBehaviour
{
    private float sinDist = 2f;

    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;

    private Rigidbody2D playerRigidbody;
    private Animator animator;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isDead)
        return;

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            jumpCount++;
            playerRigidbody.linearVelocity = Vector3.zero;
            
            Vector3 jumpPos = transform.position;

            transform.position = jumpPos + new Vector3(0f, Mathf.Sin(2f) * sinDist, 0f);

            if (jumpCount == 2)
            {
                animator.SetTrigger("DoubleJump");
            }
        }

        animator.SetBool("Grounded", isGrounded);
       
    }

    private void Die()
    {
        animator.SetTrigger("Die");

        playerRigidbody.linearVelocity = Vector2.zero;
        isDead = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dead" && !isDead)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

}
