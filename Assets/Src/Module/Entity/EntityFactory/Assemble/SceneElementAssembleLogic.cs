/// <summary>
/// 场景物件装配逻辑
/// </summary>
public class SceneElementAssembleLogic : IEntityTypeAssembleLogic
{
    public void AssembleSceneEntity(SceneEntity entity, Bian.EntityType entityType)
    {
        _ = entity.Root.AddComponent<SceneElementSvrDataProcess>();
    }
}