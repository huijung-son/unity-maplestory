
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FG_UIInven_MGRadio: MonoBehaviour
{
    //[SerializeField] private GameObject[] _mnuList;
    //[SerializeField] private Button[] firstSelected;
    [SerializeField] private GameObject prefab = null;
    [SerializeField] private Sprite[] levelPics;
    [SerializeField] private Canvas picsFeild;
    [SerializeField] private TextMeshProUGUI textField;

    //private void Awake()
    //{
    //    prefab = GetComponent<GameObject>();
    //}
    public void OnValueChangedWithSlider(float _value)
    {
        Debug.Log("OnValueChangedWithSlider: " + _value);
    }

    public void Toggle(Toggle _toggle)
    {
        if (_toggle)
        {
            switch (_toggle.name)
            {
                case "SkinToggle":
                    //picsFeild.gameObject = prefab;
                    textField.text = "Skin";
                    break;
                case "ItemToggle":
                    //_piField.
                    textField.text = "Item";
                    break;
            }
        }

    }

}
