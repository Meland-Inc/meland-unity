using System.Collections.Generic;
using UnityGameFramework.Runtime;
using Bian;

/// <summary>
/// 生产各种实体类型的初始场景实体的工厂
/// </summary>
public static class SceneEntityFactory
{
    //各实体类型的初始装配逻辑
    private static readonly Dictionary<EntityType, IEntityTypeAssembleLogic> s_assembleLogic = new()
    {
        { EntityType.EntityTypeMapObject, new SceneElementAssembleLogic() },
        { EntityType.EntityTypeSpecialBuild, new SceneElementAssembleLogic() },
        { EntityType.EntityTypePlayer, new PlayerRoleAssembleLogic() },
        { EntityType.EntityTypeMonster, new MonsterAssembleLogic() },
        { EntityType.EntityTypePuppet, new PuppetAssembleLogic() },
    };

    /// <summary>
    /// 创建场景实体
    /// </summary>
    /// <param name="entityID">场景实体ID</param>
    /// <param name="entityType">实体类型</param>
    /// <returns></returns>
    public static SceneEntity CreateSceneEntity(string entityID, EntityType entityType, bool isMainRole)
    {
        if (!s_assembleLogic.TryGetValue(entityType, out IEntityTypeAssembleLogic assembleLogic))
        {
            Log.Fatal($"Can not find assemble logic for entity type {entityType}");
            return null;
        }

        SceneEntity entity = new(isMainRole, $"{entityType}_{entityID}");
        entity.BaseData.Init(entityID, entityType);
        assembleLogic.AssembleSceneEntity(entity, entityType);
        return entity;
    }

    /// <summary>
    /// 创建主角色实体
    /// </summary>
    /// <param name="entityID"></param>
    /// <returns></returns>
    public static SceneEntity CreateMainPlayerRole(string entityID)
    {
        SceneEntity entity = CreateSceneEntity(entityID, EntityType.EntityTypePlayer, true);
        entity.SetRootName($"mainPlayerRole_{entityID}");

        //主角特殊逻辑
        entity.Root.AddComponent<MoveNetRequest>().enabled = false;
        return entity;
    }
}