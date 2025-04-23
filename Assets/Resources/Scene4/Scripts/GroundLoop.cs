using UnityEngine;

public class GroundLoop : MonoBehaviour
{
    private float width;

    private void Awake()
    {
        BoxCollider2D groundCollider = GetComponent<BoxCollider2D>();
        width = groundCollider.size.x;
    }

    private void Update()
    {
        if (transform.position.x <= -width)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
