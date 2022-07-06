using Bian;
using Google.Protobuf.Collections;
using UnityEngine;

public partial class SceneEntityMgr : SceneModuleBase
{
    public void NetInitMainRole(Player playerData, EntityLocation location)
    {
        MLog.Info(eLogTag.entity, $"NetInitMainRole id={playerData.Id} [{location.Pos.X} {location.Pos.Y} {location.Z}]");

        DataManager.MainPlayer.InitRoleData(playerData.Id);
        SceneEntity sceneRole = SceneModule.EntityMgr.AddMainPlayerRole(playerData.Id);
        sceneRole.GetComponent<NetInputMove>().ForcePosition(location, playerData.Dir);

        EntityWithLocation svrEntity = new()//封装一个统一包 服务器本来用统一的更好
        {
            Player = playerData,
            Location = location,
            Id = playerData.Id,
            Type = EntityType.EntityTypePlayer

        };
        sceneRole.GetComponent<EntitySvrDataProcess>().SvrDataInit(svrEntity);

        MainPlayerMoveInput moveInput = sceneRole.GetComponent<MainPlayerMoveInput>();
        moveInput.MoveSpeed = sceneRole.GetComponent<EntityMoveData>().Speed;
        moveInput.PushDownForce = Vector3.zero;//TODO:现在场景没有地表碰撞 不能加向下力 否则一直往下掉
        sceneRole.GetComponent<MoveNetRequest>().enabled = true;

        Message.MainPlayerRoleInitFinish.Invoke();
    }

    public void NetAddUpdateEntity(RepeatedField<EntityWithLocation> entitys)
    {
        MLog.Info(eLogTag.entity, $"NetAddUpdateEntity count={entitys.Count}");

        foreach (EntityWithLocation svrEntity in entitys)
        {
            try
            {
                SceneEntity entity = AddSceneEntity(svrEntity.Id, svrEntity.Type);

                if (svrEntity.Type is EntityType.EntityTypePlayer or EntityType.EntityTypeMonster)
                {
                    entity.GetComponent<NetInputMove>().ForcePosition(svrEntity.Location, svrEntity.Direction);
                }
                else
                {
                    entity.DirectSetSvrPosition(svrEntity.Location);
                    entity.DirectSetSvrDir(svrEntity.Direction);
                }

                if (entity.TryGetComponent(out EntitySvrDataProcess dataProcess))
                {
                    dataProcess.SvrDataInit(svrEntity);
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
            try
            {
                RemoveSceneEntity(idInfo.Id);
            }
            catch (System.Exception)
            {
                MLog.Error(eLogTag.entity, $"NetRemoveEntity error =[{idInfo.Id},{idInfo.Type}]");
                continue;
            }
        }
    }
}