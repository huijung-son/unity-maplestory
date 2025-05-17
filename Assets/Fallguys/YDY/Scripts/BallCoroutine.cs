using System.Collections;
using UnityEngine;

public class BallCoroutine : MonoBehaviour
{
    
    [SerializeField] private Transform leftTr = null;
    [SerializeField] private Transform rightTr = null;


    private void Start()
    {
        StartCoroutine(PathCoroutine());
    }

    private IEnumerator PathCoroutine()
    {
        transform.position = leftTr.position;
        while (true)
        {
            transform.position =
                Vector3.Lerp(transform.position,
                             rightTr.position,
                             Time.deltaTime);

            yield return null;
        }
    }

}
