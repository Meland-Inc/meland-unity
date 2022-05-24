using System.Collections.Generic;
using UnityGameFramework.Runtime;
public class UICenter : GameFrameworkComponent
{
    public const string FORM_ASSET_PREFIX = "Assets/Res/Prefab/UI/";
    private Dictionary<eFormID, string> _dicFormAsset;
    private Dictionary<eFormID, int> _dicFormCacheID;
    private void Start()
    {
        InitFormAssetConfig();
        _dicFormCacheID = new();
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
        _dicFormAsset = new()
        {
            { eFormID.main,  "FormTest" }
        };
    }

    public string GetFormAsset(eFormID formID)
    {
        if (_dicFormAsset.TryGetValue(formID, out string value))
        {
            return string.Format("{0}{1}.prefab", FORM_ASSET_PREFIX, value);
        }

        return "";
    }

    public int GetFormCacheID(eFormID formID)
    {
        if (_dicFormCacheID.TryGetValue(formID, out int value))
        {
            return value;
        }

        return -1;
    }

    public void SetFormCacheID(eFormID formID, int serialID)
    {
        _dicFormCacheID.Add(formID, serialID);
    }
}

