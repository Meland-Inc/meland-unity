using System.Collections.Generic;
using Bian;
using UnityEngine;
/// <summary>
/// 主角插槽数据
/// </summary>
public class MainRoleSlotData : MonoBehaviour
{
    /// <summary>
    /// 角色插槽数据
    /// </summary>
    /// <value></value>
    public Dictionary<AvatarPosition, ItemSlot> ItemSlotDic { get; private set; }
    public void SetItemSlot(IEnumerable<ItemSlot> itemSlots)
    {
        if (ItemSlotDic == null)
        {
            ItemSlotDic = new Dictionary<AvatarPosition, ItemSlot>();
        }

        ItemSlotDic.Clear();
        foreach (ItemSlot slot in itemSlots)
        {
            ItemSlotDic.Add(slot.Position, slot);
        }
    }
}