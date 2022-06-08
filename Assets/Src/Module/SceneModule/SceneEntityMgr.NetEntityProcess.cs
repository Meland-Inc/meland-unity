using Bian;
using Google.Protobuf.Collections;

public partial class SceneEntityMgr : SceneModuleBase
{
    public void NetInitMainRole(Player playerData, EntityLocation location)
    {
        MLog.Info(eLogTag.entity, $"NetInitMainRole id={playerData.Id} [{location.Pos.X} {location.Pos.Y} {location.Z}]");

        DataManager.MainPlayer.InitRoleData(playerData.Id);
        SceneEntity sceneRole = SceneModule.EntityMgr.AddMainPlayerRole(playerData.Id);
        sceneRole.Root.GetComponent<NetInputMove>().ForcePosition(location, playerData.Dir);
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