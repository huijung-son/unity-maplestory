using UnityEngine.UI;
using UnityEngine;

public class FG_BarPlayer : MonoBehaviour
{
    private RectTransform tr = null;
    private RectTransform imgTrBar = null;

    private void Awake()
    {
        tr = GetComponent<RectTransform>();
        Image[] imgs = GetComponentsInChildren<Image>();
        imgTrBar = imgs[0].GetComponent<RectTransform>();
    }

    public void UpdatePosition(Vector3 _worldPos)
    {
        Vector3 worldToScreen = Camera.main.WorldToScreenPoint(_worldPos);
        worldToScreen.y += 100f;
        tr.position = worldToScreen;
    }


}
