using System;
using System.Collections.Generic;
using UnityEngine;
using MelandGame3;
using Google.Protobuf.Collections;
using System.Reflection;

/// <summary>
/// 自己玩家数据
/// </summary>
public class MainPlayerModel : DataModelBase
{
    [SerializeField]
    private Player _roleData;
    public Player RoleData => _roleData;
    /// <summary>
    /// 角色ID 也是场景实体ID
    /// </summary>
    public string RoleID => _roleData.Id;

    public int RoleLv => _roleData.Profile.Lv;
    public int RoleExp => Convert.ToInt32(_roleData.Profile.Exp);

    /// <summary>
    /// 账号和登陆相关数据 不为null
    /// </summary>
    /// <value></value>
    public AccountData AccountData { get; private set; }

    /// <summary>
    /// 场景中的主角色 角色数据从这个上面拿 可能为null
    /// </summary>
    public SceneEntity Role { get; private set; }

    /// <summary>
    /// 角色插槽数据
    /// </summary>
    /// <value></value>
    public Dictionary<AvatarPosition, ItemSlot> ItemSlotDic { get; private set; }

    public void Awake()
    {
        AccountData = new AccountData();
    }

    /// <summary>
    /// 初始化角色的数据 不管有没有场景角色 纯数据
    /// </summary>
    /// <param name="roleData"></param>
    public void InitRoleData(Player roleData)
    {
        _roleData = roleData;
    }

    /// <summary>
    /// 设置场景中的主角色 角色数据都从这个上面拿
    /// </summary>
    /// <param name="role"></param>
    public void SetRole(SceneEntity role)
    {
        Role = role;
    }

    public void SetItemSlot(RepeatedField<ItemSlot> itemSlots)
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

    public void UpdateProfile(IEnumerable<EntityProfileField> fields, int value, string strValue = "")
    {
        foreach (EntityProfileField field in fields)
        {
            UpdateProfile(field, value, strValue);
        }
    }

    /// <summary>
    /// 根据枚举字段更新角色信息
    /// </summary>
    /// <param name="field"></param>
    /// <param name="value"></param>
    /// <param name="strValue"></param>
    public void UpdateProfile(EntityProfileField field, int value, string strValue = "")
    {
        PropertyInfo propertyInfo;
        try
        {
            propertyInfo = typeof(EntityProfile).GetProperty(RoleDefine.RoleConfig.RoleProfileFieldDict[field]);
        }
        catch
        {
            MLog.Error(eLogTag.role, $"UpdateProfile error {field}, {value}, {strValue}");
            return;
        }

        if (string.IsNullOrEmpty(strValue))
        {
            propertyInfo.SetValue(RoleData.Profile, value);
        }
        else
        {
            propertyInfo.SetValue(RoleData.Profile, strValue);
        }

        Message.RoleProfileUpdated.Invoke(field);//TODO:需要优化，可能一次性更新多个属性，没必要每次都触发
    }

    public void UpdateProfile(IEnumerable<EntityProfileUpdate> profileUpdate)
    {
        foreach (EntityProfileUpdate update in profileUpdate)
        {
            UpdateProfile(update.Field, update.CurValue, update.CurValueStr);
        }
    }

    public void UpdateProfile(EntityProfile profile)
    {
        RoleData.Profile = profile;
        Message.RoleProfileUpdated.Invoke(EntityProfileField.EntityProfileFieldUnKnown);
    }
}