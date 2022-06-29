/// <summary>
/// monster装配
/// </summary>
public class MonsterAssembleLogic : IEntityTypeAssembleLogic
{
    public void AssembleSceneEntity(SceneEntity entity, MelandGame3.EntityType entityType)
    {
        _ = entity.AddComponent<NetInputMove>();
        _ = entity.AddComponent<MonsterSvrDataProcess>();
    }
}