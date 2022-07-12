using UnityEngine;

/// <summary>
/// 纸片元素渲染逻辑 程序使用的GF实体渲染逻辑类
/// </summary>
public class PaperElementRender : SceneEntityRenderBase
{
    public SpriteRenderer SpriteRenderer;
    private PaperRender _addedPaperRender;
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

        if (_renderData.IsLookCamera)//由于目前是使用统一的纸片预制件 所以需要走这个配置来决定是否添加PaperRender
        {
            _addedPaperRender = SpriteRenderer.gameObject.AddComponent<PaperRender>();
            _addedPaperRender.PreviewAutoFindCamera = false;
            _addedPaperRender.SetLookedTargetCamera(Camera.main);
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

        if (_addedPaperRender != null)
        {
            Destroy(_addedPaperRender);
            _addedPaperRender = null;
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
