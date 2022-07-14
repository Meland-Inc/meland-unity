/// <summary>
/// spine 2D动画的实体渲染逻辑
/// </summary>
public class Avatar2DEntityRender : SceneEntityRenderBase
{
    protected Avatar2D Avatar2D;
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

        ProcessAvatar();
    }

    protected override void OnRecycle()
    {
        Destroy(Avatar2D);
        Avatar2D = null;

        base.OnRecycle();
    }

    /// <summary>
    /// 给子类处理avatar使用
    /// </summary>
    protected virtual void ProcessAvatar()
    {
        Avatar2D = gameObject.AddComponent<Avatar2D>();
        RefSceneEntity.GetComponent<SpineAnimationCpt>().Init(Avatar2D.SkeletonAnimation);
    }
}