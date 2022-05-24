using System;
using System.Collections.Generic;
using UnityEngine;
using Bian;

/// <summary>
/// 场景实体管理 管理着和服务器同步的所有实体
/// </summary>
[DisallowMultipleComponent]
public partial class SceneEntityMgr : MonoBehaviour
{
    /// <summary>
    /// 场景所有实体 包括了主角
    /// </summary>
    /// <returns></returns>
    private readonly Dictionary<string, SceneEntity> _entityMap = new();


    /// <summary>
    /// 获取存在的场景实体
    /// </summary>
    /// <param name="entityID"></param>
    /// <returns>如果没有会返回null</returns>
    public SceneEntity GetSceneEntity(string entityID)
    {
        if (_entityMap.TryGetValue(entityID, out SceneEntity entity))
        {
            return entity;
        }
        return null;
    }

    /// <summary>
    /// 添加一个场景实体 主角使用另外一个方法
    /// </summary>
    /// <param name="entityID"></param>
    /// <param name="entityType"></param>
    /// <returns></returns>
    public SceneEntity AddSceneEntity(string entityID, EntityType entityType)
    {
        if (_entityMap.ContainsKey(entityID))
        {
            MLog.Error(eLogTag.entity, $"Entity {entityID} already exist,type={entityType}");
            RemoveSceneEntity(entityID);
        }

        SceneEntity entity = SceneEntityFactory.CreateSceneEntity(entityID, entityType);
        try
        {
            entity.Init();
        }
        catch (Exception e)
        {
            MLog.Error(eLogTag.entity, $"Entity {entityID} init failed,type={entityType},error={e}");
        }
        _entityMap.Add(entityID, entity);

        eSceneGroup sceneGroup = GetEntitySceneGroup(entityType);
        SceneModule.SceneRender.AddToGroup(entity.Transform, sceneGroup);

        return entity;
    }

    /// <summary>
    /// 移除一个场景实体 主角不使用这个方法
    /// </summary>
    /// <param name="entityID"></param>
    public void RemoveSceneEntity(string entityID)
    {
        if (!_entityMap.TryGetValue(entityID, out SceneEntity entity))
        {
            MLog.Error(eLogTag.entity, $"Entity {entityID} not exist");
            return;
        }

        SceneModule.SceneRender.RemoveFromGroup(entity.Transform);

        _ = _entityMap.Remove(entityID);
        try
        {
            entity.Dispose();
        }
        catch (Exception e)
        {
            MLog.Error(eLogTag.entity, $"Entity {entityID} dispose failed,error={e}");
        }
    }

    /// <summary>
    /// 添加主角
    /// </summary>
    /// <param name="entityID"></param>
    /// <returns></returns>
    public SceneEntity AddMainPlayerRole(string entityID)
    {
        SceneEntity oldRole = DataManager.MainPlayer.Role;
        if (oldRole != null)
        {
            MLog.Error(eLogTag.entity, $"add main role repeated,cur={oldRole.BaseData.ID} target={entityID}");
            RemoveMainPlayerRole();
        }

        SceneEntity newRole = SceneEntityFactory.CreateMainPlayerRole(entityID);
        newRole.Init();
        newRole.SetRootParent(SceneModule.SceneRender.Root);
        DataManager.MainPlayer.SetRole(newRole);
        _entityMap.Add(entityID, newRole);
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

        _ = _entityMap.Remove(role.BaseData.ID);
        DataManager.MainPlayer.SetRole(null);
        role.SetRootParent(null);
        role.Dispose();
    }

    /// <summary>
    /// 获取实体对应的场景分组
    /// </summary>
    /// <param name="entityType"></param>
    /// <returns></returns>
    private eSceneGroup GetEntitySceneGroup(EntityType entityType)
    {
        return entityType switch
        {
            EntityType.EntityTypePlayer => eSceneGroup.playerRole,
            EntityType.EntityTypeMonster => eSceneGroup.fightRole,
            EntityType.EntityTypeNpc or EntityType.EntityTypePuppet => eSceneGroup.neutralRole,
            EntityType.EntityTypeMapObject or EntityType.EntityTypeSpecialBuild => eSceneGroup.element,
            _ => eSceneGroup.other,
        };
    }
}