using UnityEngine;

public class PersonMoving : MonoBehaviour
{
    [SerializeField] private Animator a;

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.position += Vector3.left * 2f * Time.deltaTime;
    }
}
