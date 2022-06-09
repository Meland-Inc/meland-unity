using UnityEngine;

public class PlayerRoleRender : SceneEntityRenderBase
{
    public TargetSameDirection TargetSameDirection;

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
    }

    protected override void OnRecycle()
    {
        base.OnRecycle();
    }
}