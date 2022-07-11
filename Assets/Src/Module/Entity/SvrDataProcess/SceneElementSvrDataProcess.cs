/** 
 * @Author xiangqian
 * @Description 
 * @Date 2022-07-06 11:55:33
 * @FilePath /Assets/Src/Module/Entity/SvrDataProcess/SceneElementSvrDataProcess.cs
 */
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

        EntityConfigData configData = gameObject.AddComponent<EntityConfigData>();
        configData.InitEntityConfig(dr);

        IEntityRenderData renderData = configData;

        if (renderData.AssetType == (int)DREntityDefine.eAssetType.Model3D)
        {
            GFEntry.Entity.ShowEntity<ModelElementRender>(svrEntity.Id.GetHashCode(), renderData.AssetFullPath, EntityDefine.GF_ENTITY_GROUP_ELEMENT, (int)eLoadPriority.SceneElement, svrEntity.Id);
        }
        else if (!string.IsNullOrEmpty(dr.AnimeName))//动画物件
        {
            //TODO:没有资源
            // GFEntry.Entity.ShowEntity<Avatar2DEntityRender>(svrEntity.Id.GetHashCode(), renderData.AssetFullPath, EntityDefine.GF_ENTITY_GROUP_ELEMENT, (int)eLoadPriority.SceneElement, svrEntity.Id);
        }
        else
        {
            if (dr.IsHorizontal)
            {
                string prefabAsset = Path.Combine(AssetDefine.PATH_MAP_ELEMENT, EntityDefine.HORIZONTAL_ELEMENT_PREFAB_ASSET);
                GFEntry.Entity.ShowEntity<HorizontalElementRender>(svrEntity.Id.GetHashCode(), prefabAsset, EntityDefine.GF_ENTITY_GROUP_ELEMENT, (int)eLoadPriority.SceneElement, svrEntity.Id);
            }
            else
            {
                string prefabAsset = Path.Combine(AssetDefine.PATH_MAP_ELEMENT, EntityDefine.PAPER_ELEMENT_PREFAB_ASSET);
                GFEntry.Entity.ShowEntity<PaperElementRender>(svrEntity.Id.GetHashCode(), prefabAsset, EntityDefine.GF_ENTITY_GROUP_ELEMENT, (int)eLoadPriority.SceneElement, svrEntity.Id);
            }
        }
    }
}
