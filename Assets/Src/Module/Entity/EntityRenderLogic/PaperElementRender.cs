using UnityEngine;

/// <summary>
/// 纸片元素渲染逻辑
/// </summary>
public class PaperElementRender : SceneEntityRenderBase
{
    public SpriteRenderer SpriteRenderer;
    private CameraSameDirection _addedCameraSameDirection;
    private IEntityRenderData _renderData;

    protected override void OnInit(object userData)
    {
        try
        {
            base.OnInit(userData);
        }
        catch (System.Exception e)
        {
            MLog.Error(eLogTag.entity, $"PaperElementRender init error={e}");
            return;
        }

        _renderData = RefSceneEntity.GetComponent<IEntityRenderData>();

        if (_renderData.IsLookCamera)
        {
            _addedCameraSameDirection = gameObject.AddComponent<CameraSameDirection>();
            _addedCameraSameDirection.SetTargetTsm(Camera.main.transform);
        }
        else
        {
            Vector3 euler = transform.eulerAngles;
            euler.x = 0;
            transform.eulerAngles = euler;
        }

        LoadTexture();
    }

    protected override void OnRecycle()
    {
        UnloadTexture();

        if (_addedCameraSameDirection != null)
        {
            Destroy(_addedCameraSameDirection);
            _addedCameraSameDirection = null;
        }

        _renderData = null;

        base.OnRecycle();
    }

    private async void LoadTexture()
    {
        try
        {
            Sprite sprite = await BasicModule.Asset.LoadAsset<Sprite>(_renderData.AssetFullPath, GetHashCode());
            SpriteRenderer.sprite = sprite;
        }
        catch (AssetLoadException e)
        {
            MLog.Error(eLogTag.asset, $"PaperElementRender laod error ={SceneEntityID} error={e}");
        }
    }

    private void UnloadTexture()
    {
        BasicModule.Asset.UnloadAsset<Sprite>(_renderData.AssetFullPath, GetHashCode());
        SpriteRenderer.sprite = null;
    }
}
