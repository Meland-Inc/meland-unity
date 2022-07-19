using MelandGame3;
using NFT;
/// <summary>
/// 皮肤类型NFT物品
/// </summary>
public class BpSkinNftItem : BpWearableNftItem
{
    public BpSkinNftItem(Item item, NFTData nftData) : base(item, nftData)
    {

    }

    public override void UseFunc()
    {
        throw new System.NotImplementedException();
    }

    protected override eNFTQuality GetQuality()
    {
        string strValue = GetAttribute(eNFTTraitType.Rarity.ToString());
        eNFTRarity rarity = strValue.ToEnum<eNFTRarity>();
        return BackpackUtil.Rarity2Quality(rarity);
    }
}