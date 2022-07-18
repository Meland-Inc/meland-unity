using System;
using System.Collections.Generic;
using System.Reflection;
using Bian;
using UnityEngine;
public class RoleProfileData : MonoBehaviour
{
    public EntityProfile Profile { get; private set; }
    public int RoleLv => Profile.Lv;
    public int RoleExp => Convert.ToInt32(Profile.Exp);
    public void InitProfile(EntityProfile profile)
    {
        Profile = profile;
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
            propertyInfo.SetValue(Profile, value);
        }
        else
        {
            propertyInfo.SetValue(Profile, strValue);
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
        Profile = profile;
        Message.RoleProfileUpdated.Invoke(EntityProfileField.EntityProfileFieldUnKnown);
    }
}