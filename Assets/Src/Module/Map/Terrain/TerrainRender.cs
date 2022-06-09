using System.IO;
using UnityGameFramework.Runtime;
using UnityEngine;

/// <summary>
/// 地表块渲染逻辑 比较特殊 没有具体的逻辑SceneEntity 只有渲染的实体
/// </summary>
public class TerrainRender : EntityLogic
{
    public SpriteRenderer SpriteRenderer;
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        TerrainRenderTempData data = userData as TerrainRenderTempData;
        gameObject.SetActive(true);
        transform.position = data.Position;
        SceneModule.SceneRender.AddToGroup(transform, eSceneGroup.terrain);
        LoadSprite(Path.Combine("Terrain", data.TextureAsset));
    }

    protected override void OnRecycle()
    {
        //TODO:卸载资源
        gameObject.SetActive(false);
        SpriteRenderer.sprite = null;
        base.OnRecycle();
    }

    private async void LoadSprite(string spriteName)
    {
        Sprite sprite = await Resource.LoadSprite(spriteName, 5000);
        SpriteRenderer.sprite = sprite;
    }
}