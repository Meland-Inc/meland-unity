/** 
 * @Author xiangqian
 * @Description 
 * @Date 2022-07-06 11:55:33
 * @FilePath /Assets/Src/Module/Entity/SvrDataProcess/PuppetSvrDataProcess.cs
 */
using System.IO;
using Bian;

/// <summary>
/// 生物服务器数据处理 生物没有攻击行为 只是场景动物而已 装饰用
/// </summary>
public class PuppetSvrDataProcess : EntitySvrDataProcess
{
    public override void SvrDataInit(EntityWithLocation svrEntity)
    {
        Puppet svrPuppet = svrEntity.Puppet;

        if (svrPuppet.Cid is not 9001192 and not 9001193)//TODO:暂时只有这两个动物资源
        {
            return;
        }

        DREntity dr = GFEntry.DataTable.GetDataTable<DREntity>().GetDataRow(svrPuppet.Cid);
        if (dr == null)
        {
            MLog.Error(eLogTag.entity, $"PuppetSvrDataProcess not find entity dr ={svrPuppet.Cid} error =[{svrEntity.Id},{svrEntity.Type}]");
            return;
        }


        EntityConfigData configData = gameObject.AddComponent<EntityConfigData>();
        configData.InitEntityConfig(dr);

        IEntityRenderData renderData = configData;
        GFEntry.Entity.ShowEntity<Avatar2DEntityRender>(svrEntity.Id.GetHashCode(), renderData.AssetFullPath, EntityDefine.GF_ENTITY_GROUP_ROLE, (int)eLoadPriority.SceneElement, svrEntity.Id);
    }
}