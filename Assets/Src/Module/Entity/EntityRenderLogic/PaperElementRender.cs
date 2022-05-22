using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 纸片元素渲染逻辑
/// </summary>
public class PaperElementRender : SceneEntityRenderBase
{
    public TargetSameDirection TargetSameDirection;
    public SpriteRenderer SpriteRenderer;

    protected override void OnInit(object userData)
    {
        try
        {
            base.OnInit(userData);
        }
        catch (System.Exception e)
        {
            Log.Error(e.Message);
            return;
        }

        EntityRenderTempData data = userData as EntityRenderTempData;
        TargetSameDirection.SetTargetTsm(Camera.main.transform);
        LoadSprite(data.ExtraAsset);
    }

    private async void LoadSprite(string spriteName)
    {
        Sprite sprite = await Resource.LoadSprite(spriteName);
        SpriteRenderer.sprite = sprite;
    }
}
