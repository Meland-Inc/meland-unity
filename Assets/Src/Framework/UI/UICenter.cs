using System.Collections.Generic;
using UnityGameFramework.Runtime;
using FairyGUI;
public class UICenter : GameFrameworkComponent
{
    public const string FORM_ASSET_PREFIX = "Assets/Res/Prefab/UI/";
    private Dictionary<string, int> _dicFormCacheID;
    private void Start()
    {
        _dicFormCacheID = new();
        InitConfig();
        InitPackage();
    }
    public static void InitConfig()
    {
        //init config
    }

    public static void InitPackage()
    {
        // _ = UIPackage.AddPackage(eFUIPackage.Common.ToString());
    }

    public string GetFormAsset<T>() where T : FGUIForm, new()
    {
        return GetFormAsset(typeof(T).Name);
    }

    public string GetFormAsset(string formName)
    {
        return $"{FORM_ASSET_PREFIX}{formName}.prefab";
    }

    public int GetFormCacheID<T>() where T : FGUIForm, new()
    {
        return GetFormCacheID(typeof(T).Name);
    }

    public int GetFormCacheID(string assetName)
    {
        if (_dicFormCacheID.TryGetValue(assetName, out int value))
        {
            return value;
        }

        MLog.Error(eLogTag.ui, "can't find form cache id,assetName: " + assetName);
        return -1;
    }


    public void SetFormCacheID<T>(int serialID) where T : FGUIForm, new()
    {
        SetFormCacheID(typeof(T).Name, serialID);
    }

    public void SetFormCacheID(string formName, int serialID)
    {
        _dicFormCacheID.Add(formName, serialID);
    }
}

