using System.Collections.Generic;
using System.IO;
using Bian;
using Google.Protobuf.Collections;

public static class TaskUtil
{

    public static List<RewardNftData> GetRewardNftDataByDropId(int dropId, int ditamin, int exp)
    {
        List<RewardNftData> taskRewards = new();
        DRDrop dropItem = GFEntry.DataTable.GetDataTable<DRDrop>().GetDataRow(dropId);
        int[][] dropList = dropItem.DropList;
        for (int i = 0; i < dropList.Length; i++)
        {
            int[] drop = dropList[i];
            int itemId = drop[0];
            int count = drop[2];
            taskRewards.Add(CreateRewardNftDataByItemId(itemId, count));
        }

        taskRewards.Add(CreateRewardNftDataByItemId(AssetDefine.ITEMID_DITAMIN, ditamin));
        taskRewards.Add(CreateRewardNftDataByItemId(AssetDefine.ITEMID_EXP, exp));
        return taskRewards;
    }

    public static RewardNftData CreateRewardNftDataByItemId(int itemId, int count, NFT.eNFTQuality quality = NFT.eNFTQuality.Basic)
    {
        DRItem item = GFEntry.DataTable.GetDataTable<DRItem>().GetDataRow(itemId);
        string icon = Path.Combine(AssetDefine.PATH_ITEM_ICON, $"{item.Icon}.png");
        // todo item.Quality 
        RewardNftData data = new()
        {
            Cid = itemId,
            Icon = icon,
            Count = count,
            Quality = quality
        };
        return data;
    }
}