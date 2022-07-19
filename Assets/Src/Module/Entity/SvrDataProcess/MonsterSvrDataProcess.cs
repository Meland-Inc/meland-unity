/** 
 * @Author xiangqian
 * @Description 
 * @Date 2022-07-06 11:55:33
 * @FilePath /Assets/Src/Module/Entity/SvrDataProcess/MonsterSvrDataProcess.cs
 */
using System.IO;
using MelandGame3;

/// <summary>
/// monster怪物的服务器数据处理 monster是有攻击行为
/// </summary>
public class MonsterSvrDataProcess : RoleSvrDataProcess
{
    public override void SvrDataInit(SceneEntity sceneEntity, EntityWithLocation svrEntity)
    {
        base.SvrDataInit(sceneEntity, svrEntity);

        Monster svrMonster = svrEntity.Monster;

        DRMonster drMonseter = GFEntry.DataTable.GetDataTable<DRMonster>().GetDataRow(svrMonster.Cid);
        if (drMonseter == null)
        {
            MLog.Error(eLogTag.entity, $"MonsterSvrDataProcess not find monster dr ={svrMonster.Cid} error =[{svrEntity.Id},{svrEntity.Type}]");
            return;
        }

        DRRoleAsset drRoleAsset = GFEntry.DataTable.GetDataTable<DRRoleAsset>().GetDataRow(drMonseter.RoleAssetID);
        if (drRoleAsset == null)
        {
            MLog.Error(eLogTag.entity, $"MonsterSvrDataProcess not find role asset dr ={drMonseter.RoleAssetID} error =[{svrEntity.Id},{svrEntity.Type}]");
            return;
        }

        string prefabAsset = Path.Combine(AssetDefine.PATH_MONSTER, drRoleAsset.ArmatureRes + AssetDefine.SUFFIX_PREFAB);
        // GFEntry.Entity.ShowEntity<Avatar2DEntityRender>(svrEntity.Id.GetHashCode(), prefabAsset, EntityDefine.GF_ENTITY_GROUP_ROLE, (int)eLoadPriority.Monster, svrEntity.Id);
        GFEntry.Entity.ShowEntity<Avatar2DEntityRender>(prefabAsset, svrEntity.Id, EntityDefine.GF_ENTITY_GROUP_ROLE, (int)eLoadPriority.Monster);
    }
}