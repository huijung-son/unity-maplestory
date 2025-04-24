using UnityEngine;

public class ZombiMushroomScript : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
    }
}
