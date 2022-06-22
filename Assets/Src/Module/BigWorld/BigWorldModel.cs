/*
 * @Author: xiang huan
 * @Date: 2022-06-16 14:18:24
 * @Description: xiang huan
 * @FilePath: /meland-unity/Assets/Src/Module/BigWorld/BigWorldModel.cs
 * 
 */

using System.Collections.Generic;
using GameFramework;
using Google.Protobuf.Collections;
using UnityEngine;

public class BigWorldModel : DataModelBase
{
    public Dictionary<string, BigWorldPlayerAreaData> PlayerAreaDataMap { get; private set; }

    private BigWorldPlayerAreaData _mainPlayerAreaData;  //主角区域数据
    public BigWorldPlayerAreaData MainPlayerAreaData
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

    public Dictionary<ulong, BigWorldGridData> GridDataMap { get; private set; }
    public BigWorldUserAssetData AssetData { get; private set; }
    [SerializeField]
    private eBigWorldBorderRenderMode _bigWorldBorderMode;
    public eBigWorldBorderRenderMode BigWorldBorderMode => _bigWorldBorderMode;

    public void Awake()
    {
        PlayerAreaDataMap = new();
        GridDataMap = new();
        AssetData = new();
        _bigWorldBorderMode = eBigWorldBorderRenderMode.Battle;

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
        foreach (KeyValuePair<ulong, BigWorldGridData> item in GridDataMap)
        {
            ReferencePool.Release(item.Value);
        }
        GridDataMap.Clear();
    }

    /** 获取一个地格数据 */
    public BigWorldGridData GetGridData(ulong key)
    {
        _ = GridDataMap.TryGetValue(key, out BigWorldGridData gridData);
        return gridData;
    }

    /** 刷新地格 */
    public void UpdateGridData(Bian.BigWorldTile data)
    {
        ulong key = NetUtil.RCToXZKey(data.R, data.C);
        _ = GridDataMap.TryGetValue(key, out BigWorldGridData gridData);
        if (gridData != null)
        {
            gridData.SetData(data);
        }
        Message.UpdateBigWorldGridData?.Invoke(gridData);
    }

    /** 添加一个地格数据 */
    public BigWorldGridData AddGridData(Bian.BigWorldTile data)
    {
        ulong key = NetUtil.RCToXZKey(data.R, data.C);
        if (GridDataMap.TryGetValue(key, out BigWorldGridData gridData))
        {
            return gridData;
        }
        else
        {
            gridData = BigWorldGridData.Create(data);
            GridDataMap.Add(key, gridData);
            return gridData;
        }
    }

    /** 移除一个地格数据*/
    public void RemoveGridData(ulong key)
    {
        _ = GridDataMap.TryGetValue(key, out BigWorldGridData gridData);
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
    public BigWorldPlayerAreaData GetAddPlayerAreaData(Bian.BigWorldPlayerArea data)
    {
        _ = PlayerAreaDataMap.TryGetValue(data.OwnerId, out BigWorldPlayerAreaData areaData);
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
    public BigWorldPlayerAreaData GetPlayerAreaData(string uid)
    {
        _ = PlayerAreaDataMap.TryGetValue(uid, out BigWorldPlayerAreaData areaData);
        return areaData;
    }

    /**
    * 添加一个玩家区域数据
    * @param tData 玩家区域数据
*/
    public BigWorldPlayerAreaData AddPlayerAreaData(Bian.BigWorldPlayerArea data)
    {
        _ = PlayerAreaDataMap.TryGetValue(data.OwnerId, out BigWorldPlayerAreaData areaData);
        if (areaData != null)
        {
            return areaData;
        }
        areaData = BigWorldPlayerAreaData.Create(data);
        PlayerAreaDataMap.Add(data.OwnerId, areaData);
        Message.UpdateBigWorldPlayerAreaData?.Invoke(areaData.OwnerId);
        return areaData;
    }

    /** 刷新玩家区域数据 */
    public void UpdatePlayerAreaData(Bian.BigWorldPlayerArea data)
    {
        _ = PlayerAreaDataMap.TryGetValue(data.OwnerId, out BigWorldPlayerAreaData areaData);
        if (areaData == null)
        {
            return;
        }
        areaData.SetData(data);
        Message.UpdateBigWorldPlayerAreaData?.Invoke(areaData.OwnerId);
    }

    /** 移除一个玩家区域数据*/
    public void RemovePlayerAreaData(string uid)
    {
        _ = PlayerAreaDataMap.TryGetValue(uid, out BigWorldPlayerAreaData areaData);
        if (areaData == null)
        {
            return;
        }
        ReferencePool.Release(areaData);
        _ = PlayerAreaDataMap.Remove(uid);
        Message.UpdateBigWorldPlayerAreaData?.Invoke(areaData.OwnerId);
    }

    /** 移除所有玩家区域数据*/
    public void RemoveAllPlayerAreaData()
    {
        foreach (KeyValuePair<string, BigWorldPlayerAreaData> item in PlayerAreaDataMap)
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
        Bian.BigWorldPlayerArea areaData = new();
        areaData.OwnerId = BigWorldDefine.WORLD_SYSTEM_BORDER_AREA_UID;
        areaData.VipLandTiles.AddRange(rcIndexList);
        _ = GetAddPlayerAreaData(areaData);
    }

    /** 设置边界模式 */
    public void SetBigWorldBorderMode(eBigWorldBorderRenderMode mode)
    {
        _bigWorldBorderMode = mode;
        Message.UpdateBigWorldBorderRenderMode?.Invoke(mode);
    }
}