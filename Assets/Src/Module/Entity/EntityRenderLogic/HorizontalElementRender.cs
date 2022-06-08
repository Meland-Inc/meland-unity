using UnityEngine;

/// <summary>
/// 水平物件渲染器 比如地板  共用的统一预制件 需要这里面加载图片
/// </summary>
public class HorizontalElementRender : SceneEntityRenderBase
{
    public MeshRenderer MeshRenderer;
    private IEntityRenderData _renderData;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        _renderData = RefSceneEntity.GetComponent<IEntityRenderData>();
        MeshRenderer.enabled = false;//先隐藏 否则图片还没加载出来前是白色

        LoadTexture();
    }

    protected override void OnRecycle()
    {
        UnloadTexture();

        gameObject.SetActive(false);
        _renderData = null;

        transform.localScale = new Vector3(1, transform.localScale.y, 1);

        base.OnRecycle();
    }

    private async void LoadTexture()
    {
        try
        {
            Texture2D texture = await BasicModule.Asset.LoadAsset<Texture2D>(_renderData.AssetFullPath, GetHashCode());
            MeshRenderer.material.mainTexture = texture;
            MeshRenderer.enabled = true;

            //模型大小按照图片匹配
            float scaleX = texture.width * GlobalDefine.PIX_TO_POS_UNIT;
            float scaleZ = texture.height * GlobalDefine.PIX_TO_POS_UNIT;
            transform.localScale = new Vector3(scaleX, transform.localScale.y, scaleZ);
        }
        catch (AssetLoadException e)
        {
            MLog.Error(eLogTag.asset, $"HorizontalElementRender laod error ={SceneEntityID} error={e}");
        }
    }

    private void UnloadTexture()
    {
        BasicModule.Asset.UnloadAsset<Texture2D>(_renderData.AssetFullPath, GetHashCode());
        MeshRenderer.material.mainTexture = null;
    }
}
