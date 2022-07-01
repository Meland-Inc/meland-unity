/*
 * @Author: mangit
 * @LastEditTime: 2022-06-30 22:40:21
 * @LastEditors: mangit
 * @Description: 背包数据
 * @Date: 2022-06-15 18:52:50
 * @FilePath: /Assets/Src/Module/Backpack/Data/BpItemData.cs
 */
using Bian;

public abstract class BpItemData
{
    /// <summary>
    /// 服务器数据
    /// </summary>
    protected Item ItemData;
    public string Id => ItemData.Id;
    public virtual string Name => "";
    public virtual string Desc => "";
    public virtual string Icon => "";
    public virtual int Cid => ItemData.ObjectCid;
    public int Count => ItemData.Num;

    public BpItemData(Item item)
    {
        ItemData = item;
    }

    public abstract void UseFunc();

    public virtual void UpdateItem(Item item)
    {
        ItemData = item;
    }
}