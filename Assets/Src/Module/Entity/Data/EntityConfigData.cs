/** 
 * @Author xiangqian
 * @Description 
 * @Date 2022-07-06 11:55:33
 * @FilePath /Assets/Src/Module/Entity/Data/EntityConfigData.cs
 */
using System.IO;
using UnityEngine;

/// <summary>
/// 对应的Entity表配置数据
/// </summary>
[DisallowMultipleComponent]
public class EntityConfigData : MonoBehaviour, IEntityRenderData
{
    private DREntity _entityCfg;
    public int AssetType => _entityCfg.AssetType;

    public string AssetFullPath
    {
        get
        {
            if (_entityCfg.AssetType == (int)DREntityDefine.eAssetType.Model3D)
            {
                return Path.Combine(AssetDefine.PATH_MAP_ELEMENT, AssetConfigPath + AssetDefine.SUFFIX_PREFAB);
            }
            else if (!string.IsNullOrEmpty(_entityCfg.AnimeName))
            {
                return Path.Combine(AssetDefine.PATH_ANIM_MAP_ELEMENT, AssetConfigPath + AssetDefine.SUFFIX_PREFAB);
            }
            else
            {
                return Path.Combine(AssetDefine.PATH_SPRITE, "Element", AssetConfigPath + AssetDefine.SUFFIX_SPRITE);
            }
        }
    }

    public string AssetConfigPath
    {
        get
        {
            if (_entityCfg.AssetType == (int)DREntityDefine.eAssetType.Model3D)
            {
                return _entityCfg.Asset; ;
            }
            else if (!string.IsNullOrEmpty(_entityCfg.AnimeName))
            {
                return _entityCfg.AnimeName;
            }
            else
            {
                if (_entityCfg.RectTexture == null || _entityCfg.RectTexture.Length == 0)
                {
                    MLog.Error(eLogTag.dr, $"SceneElementSvrDataProcess not find rect texture ={_entityCfg.Id}");
                    return default;
                }

                string textureName = _entityCfg.RectTexture[0];//TODO:多张图片是需要随机吗？
                if (string.IsNullOrEmpty(textureName))
                {
                    MLog.Error(eLogTag.dr, $"SceneElementSvrDataProcess texture empty,cfgId={_entityCfg.Id} RectTexture.length={_entityCfg.RectTexture.Length} ");
                    return default;
                }
                return textureName;
            }
        }
    }

    public bool IsHorizontal => _entityCfg.IsHorizontal;

    public bool IsLookCamera => _entityCfg.LookCamera;

    public void InitEntityConfig(DREntity entityCfg)
    {
        _entityCfg = entityCfg;
    }
}