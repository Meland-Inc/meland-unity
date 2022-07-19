/** 
 * @Author xiangqian
 * @Description 
 * @Date 2022-07-06 11:55:33
 * @FilePath /Assets/Src/Module/Entity/SvrDataProcess/PlayerRoleSvrDataProcess.cs
 */
using System.IO;
using MelandGame3;
using UnityEngine;

/// <summary>
/// 玩家服务器数据处理 包括主角和其他玩家
/// </summary>
public class PlayerRoleSvrDataProcess : RoleSvrDataProcess
{
    public override void SvrDataInit(SceneEntity sceneEntity, EntityWithLocation svrEntity)
    {
        base.SvrDataInit(sceneEntity, svrEntity);

        Player svrPlayer = svrEntity.Player;

        if (Mathf.Approximately(svrPlayer.Profile.MoveSpeed, 0f))
        {
            MLog.Error(eLogTag.entity, $"PlayerRoleSvrDataProcess init svr data move speed invalid");
            gameObject.GetComponent<EntityMoveData>().Speed = EntityDefine.DEFINE_PLAYER_MOVE_SPEED;
        }
        else
        {
            gameObject.GetComponent<EntityMoveData>().Speed = svrPlayer.Profile.MoveSpeed;
        }

        string prefabAsset = Path.Combine(AssetDefine.PATH_ROLE, EntityDefine.PLAYER_ROLE_PREFAB_ASSET);
        // GFEntry.Entity.ShowEntity<PlayerRoleEntityRender>(svrEntity.Id.GetHashCode(), prefabAsset, EntityDefine.GF_ENTITY_GROUP_ROLE, (int)eLoadPriority.PlayerRole, svrEntity.Id);
        GFEntry.Entity.ShowEntity<PlayerRoleEntityRender>(prefabAsset, svrEntity.Id, EntityDefine.GF_ENTITY_GROUP_ROLE, (int)eLoadPriority.PlayerRole);
    }
}