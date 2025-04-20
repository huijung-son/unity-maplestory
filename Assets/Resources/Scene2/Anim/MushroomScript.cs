using UnityEngine;

public class MushroomScript : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sr;
    float moveH;
    float moveSpeed = 1f;

    void Awake()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Default", true);
            sr.flipX = false;
            transform.position += moveSpeed * Time.deltaTime * Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Default", true);
            sr.flipX = true;
            transform.position += moveSpeed * Time.deltaTime * Vector3.right;
        }
        else
        {
            animator.SetBool("Default", false);
        }
    }
}
