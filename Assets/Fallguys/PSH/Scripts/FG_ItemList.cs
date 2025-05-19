using UnityEngine;
using static UnityEditor.Progress;

public class FG_ItemList : MonoBehaviour
{
    public Transform ContentContainer;
    [SerializeField] private GameObject prefab;
    public FG_ScrollViewBase fgBase;
    //public enum EFGToggleType
    //{
    //    SkinToggle, ItemToggle
    //}
    //[System.Serializable]
    //public struct SFGItem
    //{
    //    public EFGToggleType toggleType;
    //    public int price;
    //    public static string TypeToString(EFGToggleType _itemType)
    //    {
    //        switch (_itemType)
    //        {
    //            case EFGToggleType.SkinToggle: return "SkinToggle";
    //            case EFGToggleType.ItemToggle: return "ItemToggle";
    //        }

    //        return "error";
    //    }
    //}
    ////[SerializeField] private EFGToggleType[] toggleType = null;
    ////private OnClickButtonDelegate onClickButtonCallback = null;
    public FG_ScrollViewBase.SFGItem[] items;
    public int itemLen = 0;
    private void Awake()
    {

        itemLen = items.Length;
        print("아이템 길이"+ itemLen);
    }
    private void Start()
    {
        //GameObject prefab = Resources.Load("StageItem") as GameObject;
        //FG_ScrollViewBase.SFGItem items
        for (int i = 0; i < items.Length; i++)
        {
            Transform stage = Instantiate(prefab).transform;
            FG_UIContent stageItem = stage.GetComponent<FG_UIContent>();
            stageItem.Init( i , this/*,items*/);
        }
    }

    public void OnStageClicked(FG_UIContent _Item)
    {
        print(string.Format("Stage {0}이 선택되었습니다.", (_Item.itemIndex + 1)));
    }
}
