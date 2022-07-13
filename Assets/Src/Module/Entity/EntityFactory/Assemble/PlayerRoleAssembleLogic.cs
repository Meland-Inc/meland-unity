/// <summary>
/// 玩家角色装配逻辑 主角也会先走这里
/// </summary>
public class PlayerRoleAssembleLogic : IEntityTypeAssembleLogic
{
    public void AssembleSceneEntity(EntityBase entity, eEntityType entityType)
    {
        _ = entity.AddComponent<NetInputMove>();
        _ = entity.AddComponent<PlayerRoleSvrDataProcess>();
        _ = entity.AddComponent<EntityMoveData>();
    }
}