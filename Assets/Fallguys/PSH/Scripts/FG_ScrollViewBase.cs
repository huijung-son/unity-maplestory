using UnityEngine;
using UnityEngine.UI;

public class FG_ScrollViewBase : MonoBehaviour
{
    public enum EFGToggleType
    {
        SkinToggle, ItemToggle
    }
    [System.Serializable]
    public struct SFGItem
    {
        public EFGToggleType toggleType;
        public int price;
        public static string TypeToString(EFGToggleType _itemType)
        {
            switch (_itemType)
            {
                case EFGToggleType.SkinToggle: return "SkinToggle";
                case EFGToggleType.ItemToggle: return "ItemToggle";
            }

            return "error";
        }
    }
    private GameObject btnPrefab = null;
    //[SerializeField] private EFGToggleType[] toggleType = null;
    //private OnClickButtonDelegate onClickButtonCallback = null;
    public SFGItem[] items = null;


}
