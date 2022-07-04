/// <summary>
/// 场景物件装配逻辑
/// </summary>
public class SceneElementAssembleLogic : IEntityTypeAssembleLogic
{
    public void AssembleSceneEntity(SceneEntity entity, MelandGame3.EntityType entityType)
    {
        _ = entity.AddComponent<SceneElementSvrDataProcess>();
    }
}