using UnityEngine;

public class S4Player : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Moving();
    }

    private void Moving()
    {
        Vector2 movement = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
            {
            movement.y = 1;
            }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            movement.y = -1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x = -1;
        }
        else if ( Input.GetKey(KeyCode.RightArrow))
        {
            movement.x = 1;
        }

        rb.linearVelocity = movement.normalized * moveSpeed;
    }
}
