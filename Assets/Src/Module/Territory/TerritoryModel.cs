/*
 * @Author: xiang huan
 * @Date: 2022-06-16 14:18:24
 * @Description: xiang huan
 * @FilePath /Assets/Src/Module/Territory/TerritoryModel.cs
 * 
 */

using System.Collections.Generic;
using GameFramework;
using Google.Protobuf.Collections;
using UnityEngine;

public class TerritoryModel : DataModelBase
{
    public Dictionary<string, TerritoryPlayerAreaData> PlayerAreaDataMap { get; private set; }

    private TerritoryPlayerAreaData _mainPlayerAreaData;  //主角区域数据
    public TerritoryPlayerAreaData MainPlayerAreaData
    {
        get
        {
            if (_mainPlayerAreaData == null)
            {
                _mainPlayerAreaData = GetPlayerAreaData(DataManager.MainPlayer.RoleID);
            }
            return _mainPlayerAreaData;
        }
    }

    public Dictionary<ulong, TerritoryGridData> GridDataMap { get; private set; }
    public TerritoryUserAssetData AssetData { get; private set; }
    [SerializeField]
    private eTerritoryBorderRenderMode _territoryBorderMode;
    public eTerritoryBorderRenderMode TerritoryBorderMode => _territoryBorderMode;

    public void Awake()
    {
        PlayerAreaDataMap = new();
        GridDataMap = new();
        AssetData = new();
        _territoryBorderMode = eTerritoryBorderRenderMode.Battle;

    }
    //清除数据
    public void CleanData()
    {
        RemoveAllGridData();
        RemoveAllPlayerAreaData();
        _mainPlayerAreaData = null;
    }
    /** 移除所有地格数据*/
    public void RemoveAllGridData()
    {
        foreach (KeyValuePair<ulong, TerritoryGridData> item in GridDataMap)
        {
            ReferencePool.Release(item.Value);
        }
        GridDataMap.Clear();
    }

    /** 获取一个地格数据 */
    public TerritoryGridData GetGridData(ulong key)
    {
        _ = GridDataMap.TryGetValue(key, out TerritoryGridData gridData);
        return gridData;
    }

    /** 刷新地格 */
    public void UpdateGridData(MelandGame3.BigWorldTile data)
    {
        ulong key = NetUtil.RCToXZKey(data.R, data.C);
        _ = GridDataMap.TryGetValue(key, out TerritoryGridData gridData);
        if (gridData != null)
        {
            gridData.SetData(data);
        }
        Message.UpdateTerritoryGridData?.Invoke(gridData);
    }

    /** 添加一个地格数据 */
    public TerritoryGridData AddGridData(MelandGame3.BigWorldTile data)
    {
        ulong key = NetUtil.RCToXZKey(data.R, data.C);
        if (GridDataMap.TryGetValue(key, out TerritoryGridData gridData))
        {
            return gridData;
        }
        else
        {
            gridData = TerritoryGridData.Create(data);
            GridDataMap.Add(key, gridData);
            return gridData;
        }
    }

    /** 移除一个地格数据*/
    public void RemoveGridData(ulong key)
    {
        _ = GridDataMap.TryGetValue(key, out TerritoryGridData gridData);
        if (gridData != null)
        {
            ReferencePool.Release(gridData);
            _ = GridDataMap.Remove(key);
        }
    }
    /**
    * 获取或添加一个玩家区域数据
    * @param tData 玩家区域数据
    */
    public TerritoryPlayerAreaData GetAddPlayerAreaData(MelandGame3.BigWorldPlayerArea data)
    {
        _ = PlayerAreaDataMap.TryGetValue(data.OwnerId, out TerritoryPlayerAreaData areaData);
        if (areaData != null)
        {
            UpdatePlayerAreaData(data);
        }
        else
        {
            areaData = AddPlayerAreaData(data);
        }
        return areaData;
    }

    /** 获取玩家区域数据 */
    public TerritoryPlayerAreaData GetPlayerAreaData(string uid)
    {
        _ = PlayerAreaDataMap.TryGetValue(uid, out TerritoryPlayerAreaData areaData);
        return areaData;
    }

    /**
    * 添加一个玩家区域数据
    * @param tData 玩家区域数据
*/
    public TerritoryPlayerAreaData AddPlayerAreaData(MelandGame3.BigWorldPlayerArea data)
    {
        _ = PlayerAreaDataMap.TryGetValue(data.OwnerId, out TerritoryPlayerAreaData areaData);
        if (areaData != null)
        {
            return areaData;
        }
        areaData = TerritoryPlayerAreaData.Create(data);
        PlayerAreaDataMap.Add(data.OwnerId, areaData);
        Message.UpdateTerritoryPlayerAreaData?.Invoke(areaData.OwnerId);
        return areaData;
    }

    /** 刷新玩家区域数据 */
    public void UpdatePlayerAreaData(MelandGame3.BigWorldPlayerArea data)
    {
        _ = PlayerAreaDataMap.TryGetValue(data.OwnerId, out TerritoryPlayerAreaData areaData);
        if (areaData == null)
        {
            MLog.Warning(eLogTag.territory, $"UpdatePlayerAreaData not find Player Area:{data.OwnerId}");
            return;
        }
        areaData.SetData(data);
        Message.UpdateTerritoryPlayerAreaData?.Invoke(areaData.OwnerId);
    }

    /** 移除一个玩家区域数据*/
    public void RemovePlayerAreaData(string uid)
    {
        _ = PlayerAreaDataMap.TryGetValue(uid, out TerritoryPlayerAreaData areaData);
        if (areaData == null)
        {
            MLog.Warning(eLogTag.territory, $"RemovePlayerAreaData not find Player Area:{uid}");
            return;
        }
        ReferencePool.Release(areaData);
        _ = PlayerAreaDataMap.Remove(uid);
        Message.UpdateTerritoryPlayerAreaData?.Invoke(areaData.OwnerId);
    }

    /** 移除所有玩家区域数据*/
    public void RemoveAllPlayerAreaData()
    {
        foreach (KeyValuePair<string, TerritoryPlayerAreaData> item in PlayerAreaDataMap)
        {
            ReferencePool.Release(item.Value);
        }
        PlayerAreaDataMap.Clear();
    }

    public void UpdateAssetData(Runtime.TUserAssetResponse data)
    {
        AssetData.SetData(data);
    }

    /** 初始化官方区域数据 */
    public void InitSystemAreaData(RepeatedField<int> rcIndexList)
    {
        MelandGame3.BigWorldPlayerArea areaData = new();
        areaData.OwnerId = TerritoryDefine.WORLD_SYSTEM_BORDER_AREA_UID;
        // areaData.VipLandTiles.AddRange(rcIndexList);
        _ = GetAddPlayerAreaData(areaData);
    }

    /** 设置边界模式 */
    public void SetTerritoryBorderMode(eTerritoryBorderRenderMode mode)
    {
        _territoryBorderMode = mode;
        Message.UpdateTerritoryBorderRenderMode?.Invoke(mode);
    }
}