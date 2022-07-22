/// <summary>
/// 主角装配逻辑
/// </summary>
public class MainPlayerRoleAssembleLogic : PlayerRoleAssembleLogic
{
    public override void AssembleSceneEntity(SceneEntity entity, eEntityType entityType)
    {
        base.AssembleSceneEntity(entity, entityType);

        entity.AddComponent<NetReqMove>().enabled = false;
    }
}