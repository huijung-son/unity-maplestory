using UnityEngine;

public class S4ScrollingObject : MonoBehaviour
{
    private float speed = 1f;

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
