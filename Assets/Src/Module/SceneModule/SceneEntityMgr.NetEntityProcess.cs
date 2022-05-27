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
        sceneRole.Root.GetComponent<NetInputMove>().ForcePosition(location, playerData.Dir);

        EntityWithLocation svrEntity = new()//封装一个统一包 服务器本来用统一的更好
        {
            Player = playerData,
            Location = location,
            Id = playerData.Id,
            Type = EntityType.EntityTypePlayer

        };
        sceneRole.Root.GetComponent<EntitySvrDataProcess>().SvrDataInit(svrEntity);

        sceneRole.Root.GetComponent<MainPlayerMoveInput>().MoveSpeed = sceneRole.Root.GetComponent<EntityMoveData>().Speed;

        Camera.main.transform.position = sceneRole.Transform.position + SceneDefine.MainCameraInitFollowMainRoleOffset;
        Camera.main.GetComponent<FollowTarget>().SetTargetTsm(sceneRole.Transform);
        Camera.main.GetComponent<MainCameraMoveInput>().OnSetFollowTarget();
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
                    entity.Root.GetComponent<NetInputMove>().ForcePosition(svrEntity.Location, svrEntity.Direction);
                }
                else
                {
                    entity.DirectSetSvrPosition(svrEntity.Location);
                    entity.DirectSetSvrDir(svrEntity.Direction);
                }

                if (entity.Root.TryGetComponent(out EntitySvrDataProcess dataProcess))
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