using System.IO;
using UnityGameFramework.Runtime;
using UnityEngine;

/// <summary>
/// 地表块渲染逻辑 比较特殊 没有具体的逻辑SceneEntity 只有渲染的实体
/// </summary>
public class TerrainRender : EntityLogic
{
    public MeshRenderer MeshRenderer;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        TerrainRenderTempData data = userData as TerrainRenderTempData;
        MeshRenderer.enabled = false;//先隐藏 否则图片还没加载出来前是白色
        transform.position = data.Position;
        SceneModule.SceneRender.AddToGroup(transform, eSceneGroup.terrain);
        LoadSprite(Path.Combine("Terrain", data.TextureAsset));
    }

    protected override void OnRecycle()
    {
        //TODO:卸载资源
        gameObject.SetActive(false);
        MeshRenderer.material.mainTexture = null;
        base.OnRecycle();
    }

    private async void LoadSprite(string spriteName)
    {
        Texture2D sprite = await Asset.LoadAsset<Texture2D>(Path.Combine(AssetDefine.PATH_SPRITE, $"{spriteName}.png"));
        MeshRenderer.material.mainTexture = sprite;
        MeshRenderer.enabled = true;
    }
}