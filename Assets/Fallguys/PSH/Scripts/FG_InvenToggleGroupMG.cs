using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FG_InvenToggleGroupMG : MonoBehaviour
{
    private ToggleGroup invenToggleGroupMG = null;
    //private Toggle toggleAry = null;
    private void Awake()
    {
        invenToggleGroupMG = GetComponent<ToggleGroup>();
    }
    private void Start()
    {
        invenToggleGroupMG.allowSwitchOff = OnlyTrue();
    }

    private bool OnlyTrue()
    {
        return true;
    }
}
