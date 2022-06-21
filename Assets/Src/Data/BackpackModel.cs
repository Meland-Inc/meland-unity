/*
 * @Author: mangit
 * @LastEditTime: 2022-06-21 15:45:37
 * @LastEditors: mangit
 * @Description: 背包数据中心
 * @Date: 2022-06-15 11:28:41
 * @FilePath: /Assets/Src/Data/BackpackModel.cs
*/
using Bian;
using System.Collections.Generic;

public class BackpackModel : DataModelBase
{
    /// <summary>
    /// 背包数据字典，key为背包ID，用于查询
    /// </summary>
    /// <returns></returns>
    public Dictionary<string, BpNftItem> ItemDic { get; private set; } = new();
    public Dictionary<AvatarPosition, BpWearableNftItem> WearableItemDic { get; private set; } = new();
    /// <summary>
    /// 背包数据列表，用于遍历
    /// </summary>
    /// <returns></returns>
    public List<BpNftItem> ItemList { get; private set; } = new();
    /// <summary>
    /// 背包大小
    /// </summary>
    /// <value></value>
    public int BpSize { get; private set; }

    public void InitBpSize(int size)
    {
        BpSize = size;
    }
    /// <summary>
    /// 背包数据初始化
    /// </summary>
    /// <param name="items"></param>
    public void InitData(BpNftItem[] items)
    {
        MLog.Info(eLogTag.backpack, $"init backpack data, count:{items.Length}");
        ItemDic.Clear();
        WearableItemDic.Clear();
        ItemList.Clear();

        for (int i = 0; i < items.Length; i++)
        {
            BpNftItem item = items[i];
            item.SetDataIndex(i);
            ItemList.Add(item);
            ItemDic[item.Id] = item;
            if (item is BpWearableNftItem wearableItem)
            {
                if (wearableItem.AvatarPos != AvatarPosition.AvatarPositionNone)
                {
                    WearableItemDic[wearableItem.AvatarPos] = wearableItem;
                }
            }
        }

        SceneModule.BackpackMgr.OnDataInit.Invoke();
        if (WearableItemDic.Count > 1)
        {
            SceneModule.BackpackMgr.OnWearableDataUpdated.Invoke();
        }
    }

    /// <summary>
    /// 背包数据更新
    /// </summary>
    /// <param name="items"></param>
    public void UpdateData(BpNftItem[] items)
    {
        MLog.Info(eLogTag.backpack, $"update backpack data, count:{items.Length}");
        bool isWearableDataUpdated = false;
        foreach (BpNftItem item in items)
        {
            BpNftItem oldItem = ItemDic[item.Id];
            item.SetDataIndex(oldItem.DataIndex);
            ItemDic[item.Id] = item;
            ItemList[item.DataIndex] = item;
            if (item is BpWearableNftItem newWearableItem && oldItem is BpWearableNftItem oldWearableItem)
            {
                if (newWearableItem.AvatarPos != AvatarPosition.AvatarPositionNone)//更新的部位不为none，说明当前位置有装备
                {
                    WearableItemDic[newWearableItem.AvatarPos] = newWearableItem;
                }
                else if (WearableItemDic.ContainsKey(oldWearableItem.AvatarPos))//更新的部位为none，说明当前位置没有装备，检测是否有旧的装备，有则删除
                {
                    _ = WearableItemDic.Remove(oldWearableItem.AvatarPos);
                }
                isWearableDataUpdated = true;
            }
        }

        SceneModule.BackpackMgr.OnDataUpdated.Invoke();
        if (isWearableDataUpdated)
        {
            SceneModule.BackpackMgr.OnWearableDataUpdated.Invoke();
        }
    }

    /// <summary>
    /// 新增背包数据
    /// </summary>
    /// <param name="items"></param>
    public void AddData(BpNftItem[] items)
    {
        MLog.Info(eLogTag.backpack, $"add backpack data, count:{items.Length}");
        for (int i = 0; i < items.Length; i++)
        {
            BpNftItem item = items[i];
            item.SetDataIndex(ItemList.Count + i);
            ItemDic[item.Id] = item;
            ItemList.Add(item);
        }
        SceneModule.BackpackMgr.OnDataAdded.Invoke();
    }

    /// <summary>
    /// 移除背包数据
    /// </summary>
    /// <param name="idList">id列表</param>
    public void RemoveData(string[] idList)
    {
        MLog.Info(eLogTag.backpack, $"remove backpack data, count:{idList.Length}");
        foreach (string id in idList)
        {
            BpNftItem item = ItemDic[id];
            if (item == null)
            {
                MLog.Error(eLogTag.backpack, $"remove backpack data, id:{id} not found");
                continue;
            }

            //item从ItemList后，把后面的数据索引Index往前移
            for (int i = item.DataIndex; i < ItemList.Count; i++)
            {
                ItemList[i].SetDataIndex(ItemList[i].DataIndex - 1);
            }
            ItemList.RemoveAt(item.DataIndex);
            _ = ItemDic.Remove(id);
        }
        SceneModule.BackpackMgr.OnDataRemoved.Invoke();
    }

    /// <summary>
    /// 通过调节筛选查询背包数据
    /// </summary>
    /// <param name="queryInfoList"></param>
    /// <returns></returns>
    public List<BpNftItem> QueryBpDataList(List<QueryBpDataBase> queryInfoList)
    {
        List<BpNftItem> result = new();
        foreach (BpNftItem item in ItemList)
        {
            bool isMatch = true;
            foreach (QueryBpDataBase queryInfo in queryInfoList)
            {
                if (!queryInfo.Check(item))
                {
                    isMatch = false;
                    break;
                }
            }
            if (isMatch)
            {
                result.Add(item);
            }
        }

        return result;
    }
}