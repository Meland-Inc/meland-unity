using MelandGame3;

/// <summary>
/// 场景初始化物件完成
/// </summary>
public class TInitMapElementAction : GameChannelNetMsgTActionBase<TInitMapElementResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.TinitMapElement;
    }

    protected override bool Receive(int errorCode, string errorMsg, TInitMapElementResponse rsp)
    {
        if (!base.Receive(errorCode, errorMsg, rsp))
        {
            return false;
        }

        SceneModule.EntityMgr.NetAddUpdateEntity(rsp.Entity);

        if (rsp.Final)
        {
            MLog.Info(eLogTag.entity, "场景物件初始化完成");
            Message.SceneEntityLoadFinish.Invoke();
        }

        return true;
    }
}