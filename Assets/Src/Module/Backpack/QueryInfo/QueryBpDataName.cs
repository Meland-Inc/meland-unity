/*
 * @Author: mangit
 * @LastEditTime: 2022-06-20 14:22:43
 * @LastEditors: mangit
 * @Description: 查询背通过名字查询背包
 * @Date: 2022-06-20 14:18:14
 * @FilePath: /Assets/Src/Module/Backpack/QueryInfo/QueryBpDataName.cs
 */
public class QueryBpDataName : QueryBpDataBase
{
    private readonly string _name;
    public QueryBpDataName(string name)
    {
        _name = name;
    }

    public override bool Check(BpNftItem item)
    {
        return item.Name.IndexOf(_name) != -1;
    }
}