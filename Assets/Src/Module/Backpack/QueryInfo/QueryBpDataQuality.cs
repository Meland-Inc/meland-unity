/*
 * @Author: mangit
 * @LastEditTime: 2022-06-20 17:15:06
 * @LastEditors: mangit
 * @Description: 通过品质查询背包
 * @Date: 2022-06-20 14:18:39
 * @FilePath: /Assets/Src/Module/Backpack/QueryInfo/QueryBpDataQuality.cs
 */
using System.Collections.Generic;
using NFT;

public class QueryBpDataQuality : QueryBpDataBase
{
    private readonly List<eNFTQuality> _qualityList;
    public QueryBpDataQuality(List<eNFTQuality> qualityList)
    {
        _qualityList = qualityList;
    }

    public override bool Check(BpNftItem item)
    {
        return _qualityList.IndexOf(item.Quality) != -1;
    }
}