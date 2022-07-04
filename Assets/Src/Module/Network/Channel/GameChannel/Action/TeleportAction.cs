using MelandGame3;
using UnityEngine;

/// <summary>
/// 传送协议
/// </summary>
public class TeleportAction : GameChannelNetMsgRActionBase<TeleportRequest, TeleportResponse>
{
    /// <summary>
    /// </summary>
    /// <param name="curPos">当前世界坐标</param>
    public static void Req(Vector3 curPos)
    {
        TeleportRequest req = GenerateReq();
        Vector3 svrPos = NetUtil.ClientPosToSvrPos(curPos);
        req.ToPos = new()
        {
            X = (int)svrPos.x,
            Y = (int)svrPos.y
        };
        SendAction<TeleportAction>(req);
    }

    protected override string GetEnvelopeReqName()
    {
        return "TeleportRequest";
    }

    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.Teleport;
    }

    protected override bool Receive(int errorCode, string errorMsg, TeleportResponse rsp, TeleportRequest req)
    {
        if (!base.Receive(errorCode, errorMsg, rsp, req))
        {
            MLog.Debug(eLogTag.entity, "main player Teleport error");
            return false;
        }

        return true;
    }
}