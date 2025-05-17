using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class FG_ToggleListMG : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textField;
    [SerializeField] private Toggle toggle;

    public void OnCliToggel(bool _value)
    {
        Debug.Log("OnClickToggle: " + _value);
    }

    public void OnValueChagedWithSlider(float _value)
    {
        Debug.Log("OnValueChangedWithSlider: " + _value);
    }
}
