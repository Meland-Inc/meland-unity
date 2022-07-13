using MelandGame3;
using System;
using Google.Protobuf.Collections;

public partial class SceneEntityMgr : EntityMgr
{
    public void NetInitMainRole(Player playerData, EntityLocation location)
    {
        MLog.Info(eLogTag.entity, $"NetInitMainRole id={playerData.Id} [{location.Loc.X} {location.Loc.Y} {location.Loc.Z}]");

        DataManager.MainPlayer.InitRoleData(playerData);
        SceneEntity sceneRole = SceneModule.EntityMgr.AddMainPlayerRole(Convert.ToInt64(playerData.Id));
        sceneRole.GetComponent<NetInputMove>().ForcePosition(location, playerData.Dir);

        EntityWithLocation svrEntity = new()//封装一个统一包 服务器本来用统一的更好
        {
            Player = playerData,
            Location = location,
            Id = playerData.Id,
            Type = EntityType.EntityTypePlayer

        };
        sceneRole.GetComponent<EntitySvrDataProcess>().SvrDataInit(sceneRole, svrEntity);

        MainPlayerMoveInput moveInput = sceneRole.GetComponent<MainPlayerMoveInput>();
        //moveInput.MoveSpeed = sceneRole.GetComponent<EntityMoveData>().Speed;//TODO:测试
        moveInput.PushDownForce = UnityEngine.Vector3.zero;//TODO:现在场景没有地表碰撞 不能加向下力 否则一直往下掉
        sceneRole.GetComponent<NetReqMove>().enabled = true;

        PlayerRoleAvatarData avatarData = sceneRole.AddComponent<PlayerRoleAvatarData>();
        avatarData.SetRoleCfgID(playerData.RoleId);
        avatarData.SetRoleFeature(playerData.Feature);

        Message.MainPlayerRoleInitFinish.Invoke();
    }

    public void NetAddUpdateEntity(RepeatedField<EntityWithLocation> entitys)
    {
        MLog.Info(eLogTag.entity, $"NetAddUpdateEntity count={entitys.Count}");

        foreach (EntityWithLocation svrEntity in entitys)
        {
            if (svrEntity.Type is not EntityType.EntityTypePlayer and not EntityType.EntityTypeMonster)
            {
                MLog.Warning(eLogTag.entity, $"should not update not sync entity,type:{svrEntity.Type}");
                continue;
            }

            try
            {
                EntityBase entity = AddEntity(Convert.ToInt64(svrEntity.Id), NetUtil.SvrEntityType2Client(svrEntity.Type));
                entity.GetComponent<NetInputMove>().ForcePosition(svrEntity.Location, svrEntity.Direction);

                if (entity.TryGetComponent(out EntitySvrDataProcess dataProcess))
                {
                    dataProcess.SvrDataInit(entity, svrEntity);
                }
            }
            catch (System.Exception)
            {
                MLog.Error(eLogTag.entity, $"NetAddUpdateEntity error =[{svrEntity.Id},{svrEntity.Type}]");
                continue;
            }
        }
    }

    public void NetRemoveEntity(RepeatedField<EntityId> entityIds)
    {
        MLog.Info(eLogTag.entity, $"NetRemoveEntity count={entityIds.Count}");

        foreach (EntityId idInfo in entityIds)
        {
            if (idInfo.Type is not EntityType.EntityTypePlayer and not EntityType.EntityTypeMonster)
            {
                MLog.Warning(eLogTag.entity, $"should not remove not sync entity,type:{idInfo.Type}");
                continue;
            }

            try
            {
                RemoveEntity(Convert.ToInt64(idInfo.Id));
            }
            catch (System.Exception)
            {
                MLog.Error(eLogTag.entity, $"NetRemoveEntity error =[{idInfo.Id},{idInfo.Type}]");
                continue;
            }
        }
    }
}