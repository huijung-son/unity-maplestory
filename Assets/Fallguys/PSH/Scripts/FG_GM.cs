using UnityEngine;

public class FG_GM : MonoBehaviour
{
    [SerializeField] private FG_BarPlayer barHead = null;
    [SerializeField] private FG_Player player = null;

    private void Update()
    {
        DisplayPlayerBar();
    }

    private void DisplayPlayerBar()
    {   
        barHead.UpdatePosition(player.transform.position);
    }

}
