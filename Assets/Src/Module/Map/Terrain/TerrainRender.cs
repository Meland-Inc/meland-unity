using System.IO;
using UnityGameFramework.Runtime;
using UnityEngine;

/// <summary>
/// 地表块渲染逻辑 比较特殊 没有具体的逻辑SceneEntity 只有渲染的实体
/// </summary>
public class TerrainRender : EntityLogic
{
    public MeshRenderer MeshRenderer;

    private string _texturePath;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        TerrainRenderTempData data = userData as TerrainRenderTempData;
        transform.position = data.Position;
        SceneModule.SceneRender.AddToGroup(transform, eSceneGroup.terrain);

        _texturePath = Path.Combine(AssetDefine.PATH_SPRITE, "Terrain", data.TextureAsset + AssetDefine.SUFFIX_TEXTURE);
        MeshRenderer.enabled = false;//先隐藏 否则图片还没加载出来前是白色

        LoadTexture();
    }

    protected override void OnRecycle()
    {
        UnloadTexture();

        gameObject.SetActive(false);
        _texturePath = default;
        base.OnRecycle();
    }

    private async void LoadTexture()
    {
        try
        {
            Texture2D texture = await BasicModule.Asset.LoadAsset<Texture2D>(_texturePath, GetHashCode());
            MeshRenderer.material.mainTexture = texture;
            MeshRenderer.enabled = true;
        }
        catch (AssetLoadException e)
        {
            MLog.Error(eLogTag.asset, $"TerrainRender laod error ={_texturePath} error={e}");
        }
    }

    private void UnloadTexture()
    {
        BasicModule.Asset.UnloadAsset<Texture2D>(_texturePath, GetHashCode());
        MeshRenderer.material.mainTexture = null;
    }
}