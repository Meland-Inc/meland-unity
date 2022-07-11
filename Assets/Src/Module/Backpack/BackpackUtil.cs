/*
 * @Author: mangit
 * @LastEditTime: 2022-06-20 20:11:56
 * @LastEditors: mangit
 * @Description: 背包工具类
 * @Date: 2022-06-16 16:36:05
 * @FilePath: /Assets/Src/Module/Backpack/BackpackUtil.cs
 */
using System.Collections.Generic;
using Bian;
using Google.Protobuf.Collections;
using NFT;
using static BackpackDefine;

public static class BackpackUtil
{
    public static BpNftItem[] SvrItem2ClientItem(RepeatedField<Item> items)
    {
        BpNftItem[] result = new BpNftItem[items.Count];
        for (int i = 0; i < items.Count; i++)
        {
            result[i] = BpNftItem.Create(items[i]);
        }
        return result;
    }

    /// <summary>
    /// 将老的NFT的稀有度转换为新NFT的品质，rarity -> quality
    /// </summary>
    /// <param name="rarity"></param>
    /// <returns></returns>
    public static eNFTQuality Rarity2Quality(eNFTRarity rarity)
    {
        return rarity switch
        {
            eNFTRarity.common => eNFTQuality.Basic,
            eNFTRarity.rare => eNFTQuality.Enhanced,
            eNFTRarity.epic => eNFTQuality.Advanced,
            eNFTRarity.mythic => eNFTQuality.Super,
            eNFTRarity.unique => eNFTQuality.Ultimate,
            _ => eNFTQuality.Basic,
        };
    }

    public static eNftItemSortPriority GetNftItemUITypePriority(BpNftItem nftItem)
    {
        return GetNftItemUIType(nftItem) switch
        {
            eItemUIType.Equipment => eNftItemSortPriority.Equipment,
            eItemUIType.Consumable => eNftItemSortPriority.Consumable,
            eItemUIType.Material => eNftItemSortPriority.Material,
            eItemUIType.Wearable => eNftItemSortPriority.Wearable,
            eItemUIType.Placeable => eNftItemSortPriority.Placeable,
            eItemUIType.ThirdParty => eNftItemSortPriority.ThirdParty,
            _ => eNftItemSortPriority.Unknown,
        };
    }

    public static int GetNftIemQualityPriority(BpNftItem nftItem)
    {
        return (int)nftItem.Quality;
    }

    public static eItemUIType GetNftItemUIType(BpNftItem nftItem)
    {
        if (nftItem is BpSkinNftItem)
        {
            return eItemUIType.Wearable;
        }

        if (nftItem is BpPlaceableNftItem)
        {
            return eItemUIType.Placeable;
        }

        if (nftItem is BpEquipNftItem)
        {
            return eItemUIType.Equipment;
        }

        if (nftItem is BpThirdPartyNftItem)
        {
            return eItemUIType.ThirdParty;
        }

        if (nftItem is BpFoodNftItem)
        {
            return eItemUIType.Consumable;
        }

        if (nftItem is BpMaterialNftItem)
        {
            return eItemUIType.Material;
        }

        return eItemUIType.Unknown;
    }

    /// <summary>
    /// 按指定规则排序NFT物品列表
    /// </summary>
    /// <param name="nftItemList"></param>
    public static void SortNftItemList(List<BpNftItem> nftItemList)
    {
        nftItemList.Sort(CompareNftItem);
    }

    private static int CompareNftItem(BpNftItem a, BpNftItem b)
    {
        eNftItemSortPriority uiPriorityA = GetNftItemUITypePriority(a);
        eNftItemSortPriority uiPriorityB = GetNftItemUITypePriority(b);

        if (uiPriorityA == uiPriorityB)
        {
            return GetNftIemQualityPriority(b) - GetNftIemQualityPriority(a);
        }

        return (int)uiPriorityA - (int)uiPriorityB;
    }
}