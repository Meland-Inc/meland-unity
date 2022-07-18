using MelandGame3;

/// <summary>
/// 所有角色的服务器数据处理基类
/// </summary>
public class RoleSvrDataProcess : EntitySvrDataProcess
{
    public override void SvrDataInit(EntityBase sceneEntity, EntityWithLocation svrEntity)
    {
        SpineAnimationCpt animCpt = sceneEntity.AddComponent<SpineAnimationCpt>();

        animCpt.PlayAnim(EntityDefine.ANIM_NAME_IDLE, true);
    }
}