using System.IO;
using Bian;
using UnityEngine;

public class PlayerRoleSvrDataProcess : EntitySvrDataProcess
{
    public override void SvrDataInit(EntityWithLocation svrEntity)
    {
        Player svrPlayer = svrEntity.Player;

        if (Mathf.Approximately(svrPlayer.Profile.MoveSpeed, 0f))
        {
            MLog.Error(eLogTag.entity, $"PlayerRoleSvrDataProcess init svr data move speed invalid");
            gameObject.GetComponent<EntityMoveData>().Speed = EntityDefine.DEFINE_PLAYER_MOVE_SPEED;
        }
        else
        {
            gameObject.GetComponent<EntityMoveData>().Speed = svrPlayer.Profile.MoveSpeed * NetUtil.SVR_POS_2_CLIENT_POS_SCALE;
        }

        string prefabAsset = Path.Combine(AssetDefine.PATH_ROLE, EntityDefine.PLAYER_ROLE_PREFAB_ASSET);
        EntityRenderTempData data = new()
        {
            SceneEntityID = svrEntity.Id,
            ExtraAsset = string.Empty
        };
        GFEntry.Entity.ShowEntity<PlayerRoleRender>(svrEntity.Id.GetHashCode(), prefabAsset, EntityDefine.GF_ENTITY_GROUP_ROLE, (int)eLoadPriority.PlayerRole, data);
    }
}