/*
 * @Author: xiang huan
 * @Date: 2022-06-16 14:21:37
 * @Description: 领地工具
 * @FilePath: /meland-unity/Assets/Src/Module/Territory/TerritoryUtil.cs
 * 
 */
using System.Collections.Generic;
using Google.Protobuf.Collections;
using UnityEngine;

public static class TerritoryUtil
{
    public static eDirection[] FOUR_DIR_LIST = { eDirection.UP, eDirection.DOWN, eDirection.LEFT, eDirection.RIGHT };
    private static Dictionary<eDirection, Vector2> s_dirOffsetRCMap;
    public static Vector2 GetDirOffsetVector2(eDirection dir)
    {
        if (s_dirOffsetRCMap == null)
        {
            s_dirOffsetRCMap = new()
            {
                { eDirection.UP, new Vector2(-1, 0) },
                { eDirection.DOWN, new Vector2(1, 0) },
                { eDirection.LEFT, new Vector2(0, -1) },
                { eDirection.RIGHT, new Vector2(0, 1) }
            };
        }
        _ = s_dirOffsetRCMap.TryGetValue(dir, out Vector2 offset);
        return offset;
    }

    public static void HandleAddRemoveTerritoryGrid(RepeatedField<MelandGame3.BigWorldTile> adds, RepeatedField<int> dels)
    {
        List<ulong> addList = new();
        List<ulong> delList = new();
        //删除地格数据
        if (dels != null && dels.Count > 0)
        {
            for (int index = 0; index < dels.Count; index += 2)
            {
                for (int rcIndex = dels[index]; rcIndex <= dels[index + 1]; rcIndex++)
                {
                    ulong key = NetUtil.RCIndexToXZKey(rcIndex);
                    DataManager.Territory.RemoveGridData(key);
                    delList.Add(key);
                }
            }
        }

        //添加地格数据
        if (adds != null && adds.Count > 0)
        {
            for (int index = 0; index < adds.Count; index++)
            {
                _ = DataManager.Territory.AddGridData(adds[index]);
                addList.Add(NetUtil.RCToXZKey(adds[index].R, adds[index].C));
            }
        }
        Message.UpdateTerritoryGridDataList?.Invoke(addList, delList);
    }

    public static void HandleAddRemoveTerritoryPlayerArea(RepeatedField<MelandGame3.BigWorldPlayerArea> adds, RepeatedField<string> dels)
    {
        if (dels != null && dels.Count > 0)
        {
            for (int index = 0; index < dels.Count; index++)
            {
                DataManager.Territory.RemovePlayerAreaData(dels[index]);
            }
        }

        if (adds != null && adds.Count > 0)
        {
            for (int index = 0; index < adds.Count; index++)
            {
                _ = DataManager.Territory.GetAddPlayerAreaData(adds[index]);
            }
        }
    }

}