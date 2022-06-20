/*
 * @Author: mangit
 * @LastEditTime: 2022-06-20 14:29:28
 * @LastEditors: mangit
 * @Description: 通过类型查询背包
 * @Date: 2022-06-20 14:18:51
 * @FilePath: /Assets/Src/Module/Backpack/QueryInfo/QueryBpDataType.cs
 */
using NFT;

public class QueryBpDataType : QueryBpDataBase
{
    private eNFTType _type;
    public QueryBpDataType(eNFTType type)
    {
        _type = type;
    }

    public override bool Check(BpNftItem item)
    {
        return item.GetAttribute(eNFTTraitType.Type.ToString()) == _type.ToString();
    }
}