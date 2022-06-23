using System.IO;
using UnityEngine;

/// <summary>
/// 纸片元素渲染逻辑
/// </summary>
public class PaperElementRender : SceneEntityRenderBase
{
    public TargetSameDirection TargetSameDirection;
    public SpriteRenderer SpriteRenderer;

    private string _texturePath;

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
            MLog.Error(eLogTag.entity, $"PaperElementRender init error={e}");
            return;
        }

        EntityRenderTempData data = userData as EntityRenderTempData;
        TargetSameDirection.SetTargetTsm(Camera.main.transform);

        _texturePath = Path.Combine(AssetDefine.PATH_SPRITE, data.ExtraAsset + AssetDefine.SUFFIX_TEXTURE);

        LoadTexture();
    }

    protected override void OnRecycle()
    {
        UnloadTexture();

        _texturePath = default;
        base.OnRecycle();
    }

    private async void LoadTexture()
    {
        Sprite sprite = await BasicModule.Asset.LoadAsset<Sprite>(_texturePath, GetHashCode());
        SpriteRenderer.sprite = sprite;
    }

    private void UnloadTexture()
    {
        BasicModule.Asset.UnloadAsset<Sprite>(_texturePath, GetHashCode());
        SpriteRenderer.sprite = null;
    }
}
