/*
 * @Author: mangit
 * @LastEditTime: 2022-06-20 09:37:53
 * @LastEditors: mangit
 * @Description: 可穿戴nft item数据
 * @Date: 2022-06-16 17:23:04
 * @FilePath: /Assets/Src/Module/Backpack/Data/BpWearableNftItem.cs
 */
using Bian;
using NFT;

public class BpWearableNftItem : BpNftItem
{
    public AvatarPosition AvatarPos => ItemData.AvatarPos;
    public BpWearableNftItem(Item item, NFTData nftData) : base(item, nftData)
    {
    }
}