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

        if (dr.RectTexture == null || dr.RectTexture.Length == 0)
        {
            MLog.Error(eLogTag.entity, $"SceneElementSvrDataProcess not find rect texture =[{svrEntity.Id},{svrEntity.Type}]");
            return;
        }

        string textureName = dr.RectTexture[0];//TODO:多张图片是需要随机吗？
        string prefabAsset = Path.Combine(ResourceDefine.PATH_MAP_ELEMENT, EntityDefine.PAPER_SCENE_ELEMENT_PREFAB_ASSET);
        EntityRenderTempData data = new()
        {
            SceneEntityID = svrEntity.Id,
            ExtraAsset = textureName
        };
        GFEntry.Entity.ShowEntity<PaperElementRender>(svrEntity.Id.GetHashCode(), prefabAsset, EntityDefine.GF_ENTITY_GROUP_ELEMENT, (int)eLoadPriority.SceneElement, data);
    }
}
