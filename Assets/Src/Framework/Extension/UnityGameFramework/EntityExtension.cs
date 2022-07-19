using System;
using Bian;
using UnityGameFramework.Runtime;

/// <summary>
/// UGF框架entity扩展 游戏会将entity只当做显示渲染元素 逻辑上的实体是SceneEntity
/// </summary>
public static class EntityExtension
{
    /// <summary>
    /// 获取实体（外观）的外观渲染器
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public static EntityLogic GetSurfaceRender(this Entity entity)
    {
        return entity.Logic;
    }

    /// <summary>
    /// 临时写的统一显示实体renderer的逻辑，方便后边统一查找被强转的实体id
    /// </summary>
    /// <param name="entityCom"></param>
    /// <param name="asset"></param>
    /// <param name="entityInfo"></param>
    /// <param name="group"></param>
    /// <param name="priority"></param>
    /// <typeparam name="T"></typeparam>
    public static void ShowEntity<T>(this EntityComponent entityCom, string asset, string svrId, string group, int priority) where T : EntityLogic
    {
        entityCom.ShowEntity<T>(svrId.GetHashCode(), asset, group, priority, Convert.ToInt64(svrId));
    }
}