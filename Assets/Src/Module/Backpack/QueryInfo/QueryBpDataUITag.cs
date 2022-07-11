/*
 * @Author: mangit
 * @LastEditTime: 2022-06-20 19:39:37
 * @LastEditors: mangit
 * @Description: 根据标签名查询背包数据
 * @Date: 2022-06-20 16:44:40
 * @FilePath: /Assets/Src/Module/Backpack/QueryInfo/QueryBpDataUITag.cs
 */
using static BackpackDefine;

public class QueryBpDataUITag : QueryBpDataBase
{
    private readonly eItemUIType _tag;

    public QueryBpDataUITag(eItemUIType tag)
    {
        _tag = tag;
    }
    public override bool Check(BpNftItem item)
    {
        if (_tag == eItemUIType.All)
        {
            return true;
        }

        switch (_tag)
        {
            case eItemUIType.All:
                return true;
            case eItemUIType.Equipment:
                return item is BpEquipNftItem;
            case eItemUIType.Consumable:
                return item is BpFoodNftItem;
            case eItemUIType.Material:
                return item is BpMaterialNftItem;
            case eItemUIType.Wearable:
                return item is BpSkinNftItem;
            case eItemUIType.Placeable:
                return item is BpPlaceableNftItem;
            case eItemUIType.ThirdParty:
                return item is BpThirdPartyNftItem;
            default:
                break;
        }

        return true;
    }
}