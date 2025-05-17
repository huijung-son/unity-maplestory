using UnityEngine;

public class FG_GM : MonoBehaviour
{
    [SerializeField] private FG_BarPlayer barHead = null;
    [SerializeField] private NetLocalPlayerMoving player = null;

    private void Update()
    {
        DisplayPlayerBar();
    }

    private void DisplayPlayerBar()
    {   
        barHead.UpdatePosition(player.gameObject.transform.position);
    }

}
