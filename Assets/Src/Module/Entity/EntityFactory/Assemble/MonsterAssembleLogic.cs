/// <summary>
/// monster装配
/// </summary>
public class MonsterAssembleLogic : IEntityTypeAssembleLogic
{
    public void AssembleSceneEntity(SceneEntity entity, Bian.EntityType entityType)
    {
        _ = entity.Root.AddComponent<NetInputMove>();

    }
}