/// <summary>
/// monster装配
/// </summary>
public class MonsterAssembleLogic : IEntityTypeAssembleLogic
{
    public void AssembleSceneEntity(EntityBase entity, eEntityType entityType)
    {
        _ = entity.AddComponent<NetInputMove>();
        _ = entity.AddComponent<MonsterSvrDataProcess>();
    }
}