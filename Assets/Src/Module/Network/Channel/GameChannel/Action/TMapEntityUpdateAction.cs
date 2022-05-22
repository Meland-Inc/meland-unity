using Bian;

/// <summary>
/// 场景实体更新
/// </summary>
public class TMapEntityUpdateAction : GameChannelNetMsgTActionBase<TMapEntityUpdateResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.TmapEntityUpdate;
    }

    protected override bool Receive(int errorCode, string errorMsg, TMapEntityUpdateResponse rsp)
    {
        if (!base.Receive(errorCode, errorMsg, rsp))
        {
            return false;
        }

        SceneModule.EntityMgr.NetAddUpdateEntity(rsp.EntityAdded);
        SceneModule.EntityMgr.NetRemoveEntity(rsp.EntityRemoved);

        return true;
    }
}