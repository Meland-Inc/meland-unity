using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 数据管理
/// </summary>
public static class DataManager
{
    private static MainPlayerModel s_mainPlayer;
    /// <summary>
    /// 当前主角数据
    /// </summary>
    /// <typeparam name="MainPlayerModel"></typeparam>
    /// <returns></returns>
    public static MainPlayerModel MainPlayer => s_mainPlayer = s_mainPlayer != null ? s_mainPlayer : GetModel<MainPlayerModel>();

    private static MapModel s_map;
    /// <summary>
    /// 当前地图数据
    /// </summary>
    public static MapModel Map => s_map = s_map != null ? s_map : GetModel<MapModel>();
    private static BackpackModel s_backpack;
    public static BackpackModel Backpack => s_backpack = s_backpack != null ? s_backpack : GetModel<BackpackModel>();

    private static TerritoryModel s_territory;
    /// <summary>
    /// 领地数据
    /// </summary>
    public static TerritoryModel Territory => s_territory = s_territory != null ? s_territory : GetModel<TerritoryModel>();

    private static GameObject s_dataRoot;
    private static readonly Dictionary<string, DataModelBase> s_modelMap = new();


    /// <summary>
    /// 获取某个数据Model
    /// </summary>
    /// <typeparam name="T">要获取的数据类名</typeparam>
    /// <returns>返回数据实例</returns>
    public static T GetModel<T>() where T : DataModelBase
    {
        if (!s_dataRoot)
        {
            s_dataRoot = new GameObject("DataRoot");
            Object.DontDestroyOnLoad(s_dataRoot);
        }

        string modelName = typeof(T).Name;

        if (s_modelMap.TryGetValue(modelName, out DataModelBase model))
        {
            return (T)model;
        }

        GameObject go = s_dataRoot.CreateChildNode(modelName);
        model = go.AddComponent<T>();
        s_modelMap.Add(modelName, model);
        return (T)model;
    }
}