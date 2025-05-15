using UnityEngine;

public class Stage1SpriteMoving : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    private void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector3.left);
    }
}
