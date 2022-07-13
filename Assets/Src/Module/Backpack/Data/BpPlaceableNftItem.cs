/*
 * @Author: mangit
 * @LastEditTime: 2022-06-20 17:17:00
 * @LastEditors: mangit
 * @Description: 可放置nft item数据
 * @Date: 2022-06-16 16:21:43
 * @FilePath: /Assets/Src/Module/Backpack/Data/BpPlaceableNftItem.cs
 */
using MelandGame3;
using NFT;

public class BpPlaceableNftItem : BpNftItem
{
    public BigWorldLandState[] TargetLand => GetTargetLand();
    public NftSkill[] Skills => GetNFTSkills();
    public BpPlaceableNftItem(Item item, NFTData nftData) : base(item, nftData)
    {

    }

    private BigWorldLandState[] GetTargetLand()
    {
        return new BigWorldLandState[0];//todo:
    }

    private NftSkill[] GetNFTSkills()
    {
        return new NftSkill[0];//todo:
    }

    protected override eNFTQuality GetQuality()
    {
        string strValue = GetAttribute(eNFTTraitType.Rarity.ToString());
        eNFTRarity rarity = strValue.ToEnum<eNFTRarity>();
        return BackpackUtil.Rarity2Quality(rarity);
    }
}