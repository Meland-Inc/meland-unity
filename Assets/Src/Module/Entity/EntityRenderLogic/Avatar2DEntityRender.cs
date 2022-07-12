/// <summary>
/// spine 2D动画的实体渲染逻辑
/// </summary>
public class Avatar2DEntityRender : SceneEntityRenderBase
{
    private Avatar2D _avatar2D;
    private SpineAnimationCpt _spineAnimationCpt;

    protected override void OnInit(object userData)
    {
        try
        {
            base.OnInit(userData);
        }
        catch (System.Exception e)
        {
            MLog.Error(eLogTag.entity, $"Avatar2DEntityRender init error={e}");
            return;
        }

        _avatar2D = gameObject.AddComponent<Avatar2D>();

        _spineAnimationCpt = gameObject.AddComponent<SpineAnimationCpt>();
        _spineAnimationCpt.Init(_avatar2D.SkeletonAnimation);

        _spineAnimationCpt.PlayAnim(EntityDefine.ANIM_NAME_IDLE, true);
    }

    protected override void OnRecycle()
    {
        Destroy(_avatar2D);
        _avatar2D = null;

        base.OnRecycle();
    }
}