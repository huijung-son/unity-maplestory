using UnityEngine;

public class S2ZombiMushroomScript : MonoBehaviour
{
    public delegate void MushroomAction();
    public static event MushroomAction mushroomAction;

    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb2;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2 = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        if (h != 0f)
        {
            spriteRenderer.flipX = h > 0;
            animator.SetBool("MoveFlag", true);
            transform.Translate(Time.deltaTime * new Vector3(h, 0f, 0f));
        }
        else
        {
            animator.SetBool("MoveFlag", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            rb2.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            mushroomAction?.Invoke();
        }
    }
}
