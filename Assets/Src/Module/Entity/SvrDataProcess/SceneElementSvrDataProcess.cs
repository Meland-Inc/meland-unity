using System.IO;
using Bian;

/// <summary>
/// 场景物件服务器数据处理
/// </summary>
public class SceneElementSvrDataProcess : EntitySvrDataProcess
{
    public override void SvrDataInit(EntityWithLocation svrEntity)
    {
        MapObject mapObject = svrEntity.MapObject;
        if (mapObject.EntityTemplate != null)
        {
            return;
        }

        DREntity dr = GFEntry.DataTable.GetDataTable<DREntity>().GetDataRow(mapObject.Cid);
        if (dr == null)
        {
            MLog.Error(eLogTag.entity, $"SceneElementSvrDataProcess not find entity dr error =[{svrEntity.Id},{svrEntity.Type}]");
            return;
        }

        //动画物件
        if (!string.IsNullOrEmpty(dr.AnimeName))
        {
            return;
        }

        EntityConfigData configData = gameObject.AddComponent<EntityConfigData>();
        configData.InitEntityConfig(dr);

        EntityRenderTempData data = new()
        {
            SceneEntityID = svrEntity.Id,
            ExtraAsset = null
        };

        if (dr.AssetType == (int)DREntityDefine.eAssetType.Model3D)
        {
            GFEntry.Entity.ShowEntity<ModelElementRender>(svrEntity.Id.GetHashCode(), configData.AssetFullPath, EntityDefine.GF_ENTITY_GROUP_ELEMENT, (int)eLoadPriority.SceneElement, data);
        }
        else
        {
            if (dr.IsHorizontal)
            {
                string prefabAsset = Path.Combine(AssetDefine.PATH_MAP_ELEMENT, EntityDefine.HORIZONTAL_ELEMENT_PREFAB_ASSET);
                GFEntry.Entity.ShowEntity<HorizontalElementRender>(svrEntity.Id.GetHashCode(), prefabAsset, EntityDefine.GF_ENTITY_GROUP_ELEMENT, (int)eLoadPriority.SceneElement, data);
            }
            else
            {
                string prefabAsset = Path.Combine(AssetDefine.PATH_MAP_ELEMENT, EntityDefine.PAPER_ELEMENT_PREFAB_ASSET);
                GFEntry.Entity.ShowEntity<PaperElementRender>(svrEntity.Id.GetHashCode(), prefabAsset, EntityDefine.GF_ENTITY_GROUP_ELEMENT, (int)eLoadPriority.SceneElement, data);
            }
        }
    }
}
