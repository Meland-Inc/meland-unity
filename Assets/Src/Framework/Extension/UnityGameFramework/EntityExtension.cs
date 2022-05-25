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
}