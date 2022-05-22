using UnityEngine;
using Bian;
using Google.Protobuf.Collections;
using UnityGameFramework.Runtime;

public partial class SceneEntityMgr : MonoBehaviour
{
    public void NetAddUpdateEntity(RepeatedField<EntityWithLocation> entitys)
    {
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
                Log.Error($"NetAddUpdateEntity error =[{svrEntity.Id},{svrEntity.Type}]", LogTag.ENTITY);
                continue;
            }
        }
    }

    public void NetRemoveEntity(RepeatedField<EntityId> entityIds)
    {
        foreach (EntityId idInfo in entityIds)
        {
            try
            {
                RemoveSceneEntity(idInfo.Id);
            }
            catch (System.Exception)
            {
                Log.Error($"NetRemoveEntity error =[{idInfo.Id},{idInfo.Type}]", LogTag.ENTITY);
                continue;
            }
        }
    }
}