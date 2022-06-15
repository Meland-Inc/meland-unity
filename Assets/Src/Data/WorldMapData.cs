using System.Collections.Generic;

/// <summary>
/// 世界地图数据中心
/// </summary>
using Bian;
using Google.Protobuf.Collections;

public class WorldMapData : DataModelBase
{
    public string MapBlockUrls { get; private set; }

    public RepeatedField<BigWorldLogoInfo> VipLandLogoInfo { get; private set; }
    private Dictionary<string, HashSet<int>> _allRawVipLandDicSet;
    private HashSet<int> _allRawVipLandSet;
    public void SetAllVipLandLogoInfo(RepeatedField<BigWorldLogoInfo> infoList)
    {
        VipLandLogoInfo = infoList;
        _allRawVipLandDicSet = new();
        _allRawVipLandSet = new();

        foreach (BigWorldLogoInfo info in infoList)
        {
            AddVipLogoInfoToLandMap(info);
        }

        SceneModule.WorldMap.OnVipLandLogoUpdated.Invoke(infoList);
    }

    public void UpdateVipLandLogoData(BigWorldLogoInfo info)
    {
        if (VipLandLogoInfo == null || VipLandLogoInfo.Count == 0)
        {
            SetAllVipLandLogoInfo(new()
            {
                info
            });
            return;
        }

        for (int i = 0; i < VipLandLogoInfo.Count; i++)
        {
            if (VipLandLogoInfo[i].PlayerId == info.PlayerId)
            {
                VipLandLogoInfo[i] = info;
                break;
            }
        }

        AddVipLogoInfoToLandMap(info);
        SceneModule.WorldMap.OnVipLandLogoUpdated.Invoke(VipLandLogoInfo);
    }

    private void AddVipLogoInfoToLandMap(BigWorldLogoInfo info)
    {
        HashSet<int> landSet = _allRawVipLandDicSet.GetValueOrDefault(info.PlayerId, new());
        landSet.Clear();

        RepeatedField<int> allLands = info.VipLands;
        foreach (BigWorldVipLandGroup logoGroup in info.VipLandGroups)
        {
            foreach (int groupLand in logoGroup.VipLands)
            {
                allLands.Add(groupLand);
            }
        }

        for (int i = 0; i < allLands.Count; i++)
        {
            if (!landSet.Contains(allLands[i]))
            {
                _ = landSet.Add(allLands[i]);
            }

            if (!_allRawVipLandSet.Contains(allLands[i]))
            {
                _ = _allRawVipLandSet.Add(allLands[i]);
            }
        }
    }

    public bool CheckIsMyLand(string playerID, int landIndex)
    {
        if (_allRawVipLandDicSet.ContainsKey(playerID))
        {
            return _allRawVipLandDicSet[playerID].Contains(landIndex);
        }

        return false;
    }
}

