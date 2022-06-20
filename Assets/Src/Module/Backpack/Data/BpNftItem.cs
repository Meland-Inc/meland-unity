using System.IO;
using System.Collections.Generic;
using System;
/*
 * @Author: mangit
 * @LastEditTime: 2022-06-20 17:17:08
 * @LastEditors: mangit
 * @Description: NFT 道具数据基类
 * @Date: 2022-06-16 15:29:26
 * @FilePath: /Assets/Src/Module/Backpack/Data/BpNftItem.cs
 */
using Bian;
using NFT;
using UnityEngine;
public class BpNftItem : BpItemData
{
    private NFTData _nftData;
    private Dictionary<string, string> _nftAttrDic;
    public override string Name => _nftData.metadata.name;
    public override string Desc => _nftData.metadata.description;
    public override string Icon => GetIcon();
    public virtual eNFTQuality Quality => GetQuality();
    public string TokenID => _nftData.tokenId;
    public string TokenURL => _nftData.tokenURL;
    public virtual bool Using => ItemData.NftUsing;


    public BpNftItem(Item item, NFTData nftData) : base(item)
    {
        InitNFTData(nftData);
    }

    private void InitNFTData(NFTData nftData)
    {
        _nftData = nftData;
        InitNFTAttribute();
    }

    private void InitNFTAttribute()
    {
        _nftAttrDic = new();
        try
        {
            for (int i = 0; i < _nftData.metadata.attributes.Length; i++)
            {
                // eNFTTraitType key = MelandUtil.ToEnum<eNFTTraitType>(_nftData.metadata.attributes[i].trait_type);
                string key = _nftData.metadata.attributes[i].trait_type;
                string value = _nftData.metadata.attributes[i].value;
                _nftAttrDic.Add(key, value);
            }
        }
        catch (Exception e)
        {
            MLog.Error(eLogTag.backpack, $"parse nft attribute error: {e.Message}");
        }
    }

    protected virtual eNFTQuality GetQuality()
    {
        string qualityStr = GetAttribute(eNFTTraitType.Rarity.ToString());
        if (!string.IsNullOrEmpty(qualityStr))
        {
            return qualityStr.ToEnum<eNFTQuality>();
        }

        MLog.Warning(eLogTag.backpack, $"nft item quality not found,return the Basic quality");
        return eNFTQuality.Basic;
    }

    private string GetIcon()
    {
        if (_nftData.isMelandAI)
        {
            DRItem drItem = GFEntry.DataTable.GetDataTable<DRItem>().GetDataRow(Cid);
            if (drItem != null)
            {
                return Path.Combine(AssetDefine.PATH_ITEM_ICON, $"{drItem.Icon}.png");
            }
        }

        return _nftData.metadata.image;
    }

    public string GetAttribute(string type)
    {
        if (_nftAttrDic.TryGetValue(type, out string value))
        {
            return value;
        }

        MLog.Warning(eLogTag.backpack, $"nft item attribute not found,type: {type}");
        return string.Empty;
    }

    public virtual EntityNftInfo GetEntityNftInfo()
    {
        EntityNftInfo info = new()
        {
            NftId = Id,
            NftType = ItemType.ItemTypeNft
        };
        return info;
    }

    public override void UseFunc()
    {
        if (Using)
        {
            MLog.Error(eLogTag.backpack, $"nft is using, id: {Id}");
            return;
        }
    }

    /// <summary>
    /// 根据服务器原始数据创建NFT道具
    /// </summary>
    /// <param name="rawItemData"></param>
    /// <returns></returns>
    public static BpNftItem Create(Item rawItemData)
    {
        string nftJson = rawItemData.NftJsonData;
        try
        {
            NFTData nftData = JsonUtility.FromJson<NFTData>(nftJson);
            BpNftItem nftItem = SpawnItem<BpNftItem>(nftData, rawItemData);
            return nftItem;
        }
        catch (Exception e)
        {
            MLog.Error(eLogTag.backpack, $"parse nft data error: {e.Message},data str: {nftJson}");
            return new BpNftItem(rawItemData, new NFTData());
        }
    }
    /// <summary>
    /// 根据nft数据生成具体类型的nft道具
    /// </summary>
    /// <param name="nftData">nft数据</param>
    /// <param name="rawItemData">原始道具数据</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    private static T SpawnItem<T>(NFTData nftData, Item rawItemData) where T : BpNftItem
    {
        if (!nftData.isMelandAI)
        {
            return new BpThirdPartyNftItem(rawItemData, nftData) as T;//第三方nft
        }

        eNFTType type = eNFTType.Unknown;
        foreach (NFTAttribute item in nftData.metadata.attributes)
        {
            if (item.trait_type == eNFTTraitType.Type.ToString())
            {
                type = item.value.ToEnum<eNFTType>();
                break;
            }
        }


        switch (type)
        {
            case eNFTType.Wearable:
                return new BpSkinNftItem(rawItemData, nftData) as T;
            case eNFTType.Placeable:
                return new BpPlaceableNftItem(rawItemData, nftData) as T;
            case eNFTType.Consumable:
                return new BpFoodNftItem(rawItemData, nftData) as T;
            case eNFTType.Material:
                return new BpMaterialNftItem(rawItemData, nftData) as T;
            case eNFTType.HeadArmor:
            case eNFTType.ChestArmor:
            case eNFTType.LegsArmor:
            case eNFTType.FeetArmor:
            case eNFTType.HandsArmor:
            case eNFTType.Sword:
            case eNFTType.Bow:
            case eNFTType.Dagger:
            case eNFTType.Spear:
                return new BpEquipNftItem(rawItemData, nftData) as T;
            default:
                return new BpNftItem(rawItemData, nftData) as T;
        }
    }
}