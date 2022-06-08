/// <summary>
/// 实体类型的装配逻辑
/// </summary>
public interface IEntityTypeAssembleLogic
{
    /// <summary>
    /// 装配场景实体
    /// </summary>
    /// <param name="entity"></param>
    public void AssembleSceneEntity(SceneEntity entity, Bian.EntityType entityType);
}