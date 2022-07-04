/*
 * @Author: xiang huan
 * @Date: 2022-06-16 14:24:43
 * @Description: 玩家领地数据
 * @FilePath: /meland-unity/Assets/Src/Module/Territory/Data/TerritoryPlayerAreaData.cs
 * 
 */

using System.Collections.Generic;
using GameFramework;
using UnityEngine;

public class TerritoryPlayerAreaData : IReference
{
    public MelandGame3.BigWorldPlayerArea SvrData { get; private set; }
    public int MapId { get; private set; }     //地图ID
    public string OwnerId { get; private set; }    //玩家ID
    public string OwnerName { get; private set; }   //玩家名字
    public string Icon { get; private set; }    //玩家icon
    public List<ulong> VipLands { get; private set; } //vip土地 客户端xz作为key
    public List<ulong> TicketLands { get; private set; }//ticket土地 客户端xz作为key
    public List<ulong> OccupiedLands { get; private set; } //攻占土地 客户端xz作为key
    public int Color { get; private set; }//领地颜色
    public HashSet<ulong> ChallengeTileMap; //可攻占格子Map 客户端xz作为key
    public TerritoryPlayerAreaData()
    {
        VipLands = new();
        TicketLands = new();
        OccupiedLands = new();
        ChallengeTileMap = new();
    }
    public static TerritoryPlayerAreaData Create(MelandGame3.BigWorldPlayerArea svrData)
    {
        TerritoryPlayerAreaData data = ReferencePool.Acquire<TerritoryPlayerAreaData>();
        data.SetData(svrData);
        return data;
    }
    public void SetData(MelandGame3.BigWorldPlayerArea svrData)
    {
        SvrData = svrData;
        MapId = svrData.MapId;
        OwnerId = svrData.OwnerId;
        OwnerName = svrData.OwnerName;
        Icon = svrData.Icon;
        AnalysisLands(svrData.VipLandTiles, VipLands);
        AnalysisLands(svrData.TicketLandTiles, TicketLands);
        AnalysisLands(svrData.OccupiedLandTiles, OccupiedLands);
        if (svrData.OwnerId == TerritoryDefine.WORLD_SYSTEM_BORDER_AREA_UID) //官方领地
        {
            Color = TerritoryDefine.BIG_WORLD_OFFICIAL_BORDER_COLOR;
        }
        else if (svrData.OwnerId == DataManager.MainPlayer.RoleID) //自己的领地
        {
            Color = TerritoryDefine.BIG_WORLD_MAIN_PLAYER_BORDER_COLOR;
            InitChallengeTileMap();
        }
        else
        {
            //Color = Util.strHashToColor(svrData.OwnerId);
        }
    }
    public void Clear()
    {
        SvrData = null;
        MapId = 0;
        OwnerId = null;
        OwnerName = null;
        Icon = null;
        Color = 0;
        VipLands.Clear();
        TicketLands.Clear();
        OccupiedLands.Clear();
        ChallengeTileMap.Clear();
    }

    public static void AnalysisLands(IList<int> svrLands, List<ulong> list)
    {
        list.Clear();
        if (svrLands != null && svrLands.Count > 0)
        {
            for (int i = 0; i < svrLands.Count; i += 2)
            {
                for (int rcIndex = svrLands[i]; rcIndex < svrLands[i + 1]; rcIndex++)
                {
                    (float x, float z) = NetUtil.RCIndexToXZ(rcIndex);
                    ulong key = MathUtil.TwoIntToUlong((int)x, (int)z);
                    list.Add(key);
                }
            }
        }
    }

    public List<ulong> GetAllLandRcList()
    {
        List<ulong> lands = new();
        lands.AddRange(VipLands);
        lands.AddRange(TicketLands);
        lands.AddRange(OccupiedLands);
        return lands;
    }

    public int GetAllLandNum()
    {
        return VipLands.Count + TicketLands.Count + OccupiedLands.Count;
    }

    /**
    * 如何判断一个格子能否攻占？
    *  条件：格子必须与玩家已攻占格子相邻（四方向），并且这个攻占格子必须能连通一个ticket或者vip格子。
    *  思路：找出所有满足上面条件的格子。
    *      1.将所有ticket和vip周围相邻的格子，放入challengeTileMap中
    *      2.遍历已攻占格子。判断是否challengeTileMap中，
    *      如果在，则表示这个已攻占格子能连通ticket或者vip格子。因此将这个格子周围相邻的格子都可以攻占，放入challengeTileMap中。
    *      3.遍历剩余已攻占格子，继续第2步操作。直到剩余已攻占格子都不在challengeTileMap中时停止。 
    */
    //初始化攻占地格map
    private void InitChallengeTileMap()
    {
        ChallengeTileMap.Clear();
        // 先将ticket和vip的周围格子放入challengeTileMap中
        for (int i = 0; i < VipLands.Count; i++)
        {
            AddChallengeKey(VipLands[i]);
        }
        for (int i = 0; i < TicketLands.Count; i++)
        {
            AddChallengeKey(TicketLands[i]);
        }

        // 遍历当前已攻占格子，判断当已攻占格子存在challengeTileMap中时，将已拥有格子周围的格子放入challengeTileMap中。
        ulong[] occupiedList = OccupiedLands.ToArray();
        for (int i = 0; i < occupiedList.Length; i++)
        {
            bool isStop = true;
            for (int j = i; j < occupiedList.Length; j++)
            {
                if (ChallengeTileMap.Contains(occupiedList[j]))
                {
                    AddChallengeKey(occupiedList[j]);
                    //已经满足的条件的格子前移，后续不在判断这个格子
                    (occupiedList[j], occupiedList[i]) = (occupiedList[i], occupiedList[j]);
                    isStop = false;
                    break;
                }
            }
            //已经没有满足条件的格子退出循环
            if (isStop)
            {
                break;
            }
        }
    }
    //找到格子周围的格子，并放入攻占格子map中
    private void AddChallengeKey(ulong key)
    {
        (int x, int z) = MathUtil.UlongToTwoInt(key);
        eDirection[] dirList = TerritoryUtil.FOUR_DIR_LIST;
        for (int index = 0; index < dirList.Length; index++)
        {
            Vector2 offset = TerritoryUtil.GetDirOffsetVector2(dirList[index]);
            ulong newKey = MathUtil.TwoIntToUlong(x + (int)offset.x, z + (int)offset.y);
            if (!ChallengeTileMap.Contains(newKey))
            {
                _ = ChallengeTileMap.Add(newKey);
            }
        }
    }

    //格子是否能挑战
    public bool HasChallengeKey(ulong key)
    {
        return ChallengeTileMap.Contains(key);
    }
}


