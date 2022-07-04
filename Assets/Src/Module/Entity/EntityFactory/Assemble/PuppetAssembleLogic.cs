/** 
 * @Author xiangqian
 * @Description 
 * @Date 2022-07-06 11:55:33
 * @FilePath /Assets/Src/Module/Entity/EntityFactory/Assemble/PuppetAssembleLogic.cs
 */

/// <summary>
/// 生物装配逻辑
/// </summary>
public class PuppetAssembleLogic : IEntityTypeAssembleLogic
{
    public void AssembleSceneEntity(SceneEntity entity, MelandGame3.EntityType entityType)
    {
        _ = entity.AddComponent<PuppetSvrDataProcess>();
    }
}