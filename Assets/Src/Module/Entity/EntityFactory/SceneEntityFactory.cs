using System.Collections.Generic;
using UnityGameFramework.Runtime;

/// <summary>
/// 生产各种实体类型的初始场景实体的工厂
/// </summary>
public static class SceneEntityFactory
{
    //各实体类型的初始装配逻辑
    private static readonly Dictionary<eEntityType, IEntityTypeAssembleLogic> s_assembleLogic = new()
    {
        {eEntityType.sceneElement, new SceneElementAssembleLogic()},
    };

    /// <summary>
    /// 创建场景实体
    /// </summary>
    /// <param name="entityID">场景实体ID</param>
    /// <param name="entityType">实体类型</param>
    /// <returns></returns>
    public static SceneEntity CreateSceneEntity(string entityID, eEntityType entityType)
    {
        if (!s_assembleLogic.TryGetValue(entityType, out IEntityTypeAssembleLogic assembleLogic))
        {
            Log.Fatal($"Can not find assemble logic for entity type {entityType}");
            return null;
        }

        SceneEntity entity = new($"{entityType}_{entityID}");
        SceneEntityBaseData baseData = entity.Root.AddComponent<SceneEntityBaseData>();
        baseData.Init(entityID, entityType);
        assembleLogic.AssembleSceneEntity(entity, entityType);
        return entity;
    }
}