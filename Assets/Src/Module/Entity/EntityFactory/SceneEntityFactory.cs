using System.Collections.Generic;
using UnityGameFramework.Runtime;

/// <summary>
/// 生产各种实体类型的初始场景实体的工厂
/// </summary>
public class SceneEntityFactory : EntityFactory<SceneEntity>
{
    //各实体类型的初始装配逻辑
    private readonly Dictionary<eEntityType, IEntityTypeAssembleLogic> _assembleLogic = new()
    {
        { eEntityType.player, new PlayerRoleAssembleLogic() },
        { eEntityType.monster, new MonsterAssembleLogic() },
    };

    /// <summary>
    /// 根据实体类型组装实体，并返回装配后的实体，如果没有对应的装配逻辑，则返回空
    /// </summary>
    /// <param name="entity"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    protected override SceneEntity AssemblyEntity(SceneEntity entity)
    {
        if (!_assembleLogic.TryGetValue(entity.BaseData.Type, out IEntityTypeAssembleLogic assembleLogic))
        {
            Log.Fatal($"Can not find assemble logic for entity type {entity.BaseData.Type}");
            return null;
        }

        assembleLogic.AssembleSceneEntity(entity, entity.BaseData.Type);
        return entity;
    }

    public SceneEntity CreateMainRoleEntity(long id)
    {
        MainRoleEntity entity = new();
        entity.InitBaseInfo(id, eEntityType.player);
        return AssemblyEntity(entity);
    }
}