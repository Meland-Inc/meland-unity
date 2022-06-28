using UnityEngine;

public class PlayerRoleRender : SceneEntityRenderBase
{
    public TargetSameDirection TargetSameDirection;
    private Avatar2D _avatar2D;
    private SpineAnimationCpt _spineAnimationCpt;

    private void OnBecameVisible()
    {
        TargetSameDirection.enabled = true;
    }

    private void OnBecameInvisible()
    {
        TargetSameDirection.enabled = false;
    }

    protected override void OnInit(object userData)
    {
        try
        {
            base.OnInit(userData);
        }
        catch (System.Exception e)
        {
            MLog.Error(eLogTag.entity, $"PlayerRoleRender init error={e}");
            return;
        }

        TargetSameDirection.SetTargetTsm(Camera.main.transform);
        _avatar2D = transform.Find("Avatar").gameObject.AddComponent<Avatar2D>();

        _spineAnimationCpt = _avatar2D.gameObject.AddComponent<SpineAnimationCpt>();
        _spineAnimationCpt.Init(_avatar2D.SkeletonAnimation);
    }

    protected override void OnRecycle()
    {
        Destroy(_avatar2D);
        _avatar2D = null;

        base.OnRecycle();
    }
}