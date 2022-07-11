
using UnityEngine;

/// <summary>
/// 3d模型元素渲染逻辑 有自己现成的材质设置
/// </summary>
public class ModelElementRender : SceneEntityRenderBase
{
    private MeshRenderer _meshRenderer;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        if (!TryGetComponent(out _meshRenderer))
        {
            MLog.Error(eLogTag.entity, $"ModelElementRender init error, no MeshRenderer,ID={SceneEntityID}");
            enabled = false;
        }
    }

    protected override void OnRecycle()
    {
        _meshRenderer = null;

        base.OnRecycle();
    }
}
