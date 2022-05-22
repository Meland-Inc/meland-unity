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

        string textureName = "";//TODO:需要使用配置
        string prefabAsset = Path.Combine(ResourceDefine.PATH_MAP_ELEMENT, EntityDefine.PAPER_SCENE_ELEMENT_PREFAB_ASSET);
        EntityRenderTempData data = new()
        {
            SceneEntityID = svrEntity.Id,
            ExtraAsset = textureName
        };
        GFEntry.Entity.ShowEntity<PaperElementRender>(svrEntity.Id.GetHashCode(), prefabAsset, EntityDefine.GF_ENTITY_GROUP_ELEMENT, (int)eLoadPriority.SceneElement, data);
    }
}
