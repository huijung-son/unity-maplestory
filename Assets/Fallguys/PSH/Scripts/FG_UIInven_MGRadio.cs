
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FG_UIInven_MGRadio: MonoBehaviour
{
    //[SerializeField] private GameObject[] _mnuList;
    //[SerializeField] private Button[] firstSelected;
    [SerializeField] private Sprite[] levelPics;
    [SerializeField] private Canvas picsFeild;
    public TextMeshProUGUI isChangeText = null; // ¹Ù²Þ

    private void Awake()
    {
        isChangeText = picsFeild.GetComponentInChildren<TextMeshProUGUI>();
    }


    public void Toggle(Toggle _toggle)
    {
        if (_toggle)
        {
            switch (_toggle.name)
            {
                case "SkinToggle":
                    isChangeText.text = "Skin";
                    break;
                case "ItemToggle":
                    isChangeText.text = "Item";
                    break;
            }
        }

    }

}