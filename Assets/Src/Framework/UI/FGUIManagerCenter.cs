using System.Collections;
using System.Collections.Generic;
using FGUIDefine;
using UnityGameFramework.Runtime;
public class FGUIManagerCenter : GameFrameworkComponent
{
    public const string FORM_ASSET_PREFIX = "Assets/Res/Prefab/UI/";
    private Dictionary<eFormID, string> _dicForm;
    private Dictionary<eFormID, int> _dicFormSerialID;
    private void Start()
    {
        InitFormAssetConfig();
        _dicFormSerialID = new();
    }
    public static void InitConfig()
    {
        //init config
    }

    public static void InitPackage()
    {
        //add default package
    }

    private void InitFormAssetConfig()
    {
        _dicForm = new()
        {
            { eFormID.main,  "FormTest" }
        };
    }

    public string GetFormAsset(eFormID formID)
    {
        if (_dicForm.TryGetValue(formID, out string value))
        {
            return string.Format("{0}{1}.prefab", FORM_ASSET_PREFIX, value);
        }

        return "";
    }

    public int GetFormSerialID(eFormID formID)
    {
        if (_dicFormSerialID.TryGetValue(formID, out int value))
        {
            return value;
        }

        return -1;
    }
}

