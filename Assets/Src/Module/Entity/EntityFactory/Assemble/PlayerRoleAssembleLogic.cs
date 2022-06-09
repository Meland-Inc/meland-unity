/// <summary>
/// 玩家角色装配逻辑 主角也会先走这里
/// </summary>
public class PlayerRoleAssembleLogic : IEntityTypeAssembleLogic
{
    public void AssembleSceneEntity(SceneEntity entity, Bian.EntityType entityType)
    {
        _ = entity.Root.AddComponent<NetInputMove>();
        _ = entity.Root.AddComponent<PlayerRoleSvrDataProcess>();
        _ = entity.Root.AddComponent<EntityMoveData>();
    }
}