/// <summary>
/// 玩家角色装配逻辑 主角也会先走这里
/// </summary>
public class PlayerRoleAssembleLogic : IEntityTypeAssembleLogic
{
    public virtual void AssembleSceneEntity(SceneEntity entity, eEntityType entityType)
    {
        _ = entity.AddComponent<NetInputMove>();
        _ = entity.AddComponent<PlayerRoleSvrDataProcess>();
        _ = entity.AddComponent<EntityMoveData>();
        _ = entity.AddComponent<SpineAnimationCpt>();
        _ = entity.AddComponent<EntityBattleData>();

        EntityStatusCtrl statusCpt = entity.AddComponent<EntityStatusCtrl>();
        statusCpt.InitFsm(
            EntityStatusCtrl.CreateStatus<IdleStatus>(),
            EntityStatusCtrl.CreateStatus<MoveStatus>()
        );
        statusCpt.StartStatus<IdleStatus>();
    }
}