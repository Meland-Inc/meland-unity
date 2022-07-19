/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 角色属性
 * @Date: 2022-06-28 13:49:44
 * @FilePath: /Assets/Src/Module/MainPlayerRole/Data/RoleAttrDiffInfo.cs
 */

public class RoleAttrDiffInfo
{
    public string AttrName { get; private set; }
    public int CurValue { get; private set; }
    public int NextValue { get; private set; }

    public RoleAttrDiffInfo(string attrName, int curValue, int nextValue)
    {
        AttrName = attrName;
        CurValue = curValue;
        NextValue = nextValue;
    }
}