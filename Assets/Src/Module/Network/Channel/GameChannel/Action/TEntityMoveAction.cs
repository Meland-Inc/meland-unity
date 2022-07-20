using System;
using MelandGame3;

/// <summary>
/// 服务器广播实体移动
/// </summary>
public class TEntityMoveAction : GameChannelNetMsgTActionBase<TEntityMoveResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.TentityMove;
    }

    protected override bool Receive(int errorCode, string errorMsg, TEntityMoveResponse rsp)
    {
        if (!base.Receive(errorCode, errorMsg, rsp))
        {
            return false;
        }

        foreach (EntityMovement entityMove in rsp.Moves)
        {
            try
            {
                SceneEntity entity = SceneModule.EntityMgr.GetEntity(Convert.ToInt64(entityMove.EntityId));
                if (entity == null)
                {
                    MLog.Error(eLogTag.entity, $"not find scene entity =[{entityMove.EntityId},{entityMove.EntityType}]");
                    continue;
                }

                if (entity.TryGetComponent(out NetInputMove netMove))
                {
                    netMove.ReceiveMoveStep(entityMove.CurLocation, entityMove.DestLocation, entityMove.Type, entityMove.Dir);
                }
            }
            catch (System.Exception e)
            {
                MLog.Error(eLogTag.move, $"rsp entity move process error,:[{entityMove.EntityId},{entityMove.EntityType}] error={e}");
                continue;
            }
        }

        return true;
    }
}