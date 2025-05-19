
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
//using UnityEngine.UIElements;


public class FG_UIInvenMGRadio: MonoBehaviour
{
    //[SerializeField] private GameObject[] _mnuList;
    //[SerializeField] private Button[] firstSelected;
    //[SerializeField] private Sprite[] _levelPics;
    [SerializeField] private Canvas picsFeild;
    [SerializeField] private TextMeshProUGUI isChangeText; // ¹Ù²Þ




    private void Awake()
    {
       // isChangeText = picsFeild.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Toggle(Toggle _toggle)
    {
        if (_toggle)
        {
            switch (_toggle.name)
            {
                case "SkinToggle":
                    //_picField.sprite = _levelPics[0];
                    //ContentContainer = _scrollRect.content;
                    isChangeText.text = "Skin";
                    break;
                case "ItemToggle":
                    //ContentContainer = _scrollRect.content;
                    isChangeText.text = "Item";
                    break;
            }
        }

    }

}