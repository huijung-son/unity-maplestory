using TMPro;
using UnityEngine;

public class FG_UIContent : MonoBehaviour
{
    public int itemIndex;
    public TextMeshProUGUI TxtStageName;

    public FG_ItemList itemManager;



    //public FG_ItemList GetItemManager()
    //{
    //    return itemManager;
    //}

    public void Init( int index, FG_ItemList itemManager/*, FG_ScrollViewBase.SFGItem[] _items*/)
    {
        this.itemManager = itemManager;

        itemIndex = index;
        TxtStageName.text = "Stage " + (index + 1).ToString();
        transform.SetParent(itemManager.ContentContainer);
    }

    public void OnClicked()
    {
        itemManager.OnStageClicked(this);
    }
}
