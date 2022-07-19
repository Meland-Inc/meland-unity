using UnityEngine;

/// <summary>
/// 场景实体管理 管理着和服务器同步的所有实体
/// </summary>
[DisallowMultipleComponent]
public partial class SceneEntityMgr : EntityMgr<SceneEntity, SceneEntityFactory>
{
    protected override SceneEntity CreateEntity(long entityID, eEntityType entityType)
    {
        return Factory.CreateSceneEntity(entityID, entityType);
    }

    /// <summary>
    /// 添加主角
    /// </summary>
    /// <param name="entityID"></param>
    /// <returns></returns>
    public SceneEntity AddMainPlayerRole(long entityID)
    {
        SceneEntity oldRole = DataManager.MainPlayer.Role;
        if (oldRole != null)
        {
            MLog.Error(eLogTag.entity, $"add main role repeated,cur={oldRole.BaseData.Id} target={entityID}");
            RemoveMainPlayerRole();
        }

        SceneEntity newRole = Factory.CreateMainRoleEntity(entityID);
        newRole.Init();
        newRole.SetRootName($"mainPlayerRole_{newRole.BaseData.Id}");
        DataManager.MainPlayer.SetRole(newRole);
        EntityDic.Add(entityID, newRole);
        return newRole;
    }

    /// <summary>
    /// 删除主角
    /// </summary>
    public void RemoveMainPlayerRole()
    {
        SceneEntity role = DataManager.MainPlayer.Role;
        if (role == null)
        {
            return;
        }

        _ = EntityDic.Remove(role.BaseData.Id);
        DataManager.MainPlayer.SetRole(null);
        role.Dispose();
    }

    /// <summary>
    /// 获取实体对应的场景分组
    /// </summary>
    /// <param name="entityType"></param>
    /// <returns></returns>
    public eSceneGroup GetEntitySceneGroup(eEntityType entityType)
    {
        return entityType switch
        {
            eEntityType.player => eSceneGroup.playerRole,
            eEntityType.monster => eSceneGroup.fightRole,
            _ => eSceneGroup.other,
        };
    }
}