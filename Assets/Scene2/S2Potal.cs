using UnityEngine;

public class S2Potal : MonoBehaviour
{
    public delegate void S2PotalEvent(bool _flag);
    public static event S2PotalEvent s2PotalEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        s2PotalEvent?.Invoke(true);
    }
}
