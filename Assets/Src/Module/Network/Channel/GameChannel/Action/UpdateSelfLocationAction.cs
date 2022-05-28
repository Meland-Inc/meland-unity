using Bian;
using UnityEngine;

/// <summary>
/// 主角移动请求
/// </summary>
public class UpdateSelfLocationAction : GameChannelNetMsgRActionBase<UpdateSelfLocationRequest, UpdateSelfLocationResponse>
{
    /// <summary>
    /// </summary>
    /// <param name="curPos">当前世界坐标</param>
    public static void Req(Vector3 curPos)
    {
        UpdateSelfLocationRequest req = GenerateReq();
        req.Movement = new()
        {
            EntityId = DataManager.MainPlayer.RoleID,
            EntityType = EntityType.EntityTypePlayer,
            CurLocation = new()
            {
                Location = NetUtil.ClientPosToSvrLoc(curPos),
                Stamp = TimeUtil.GetTimeStamp(),
            },
            DestLocation = null,
            Type = MovementType.MovementTypeRun,
            Dir = new VectorXYZ()
            {
                X = 0,
                Y = 100,
                Z = 0,
            }
        };
        SendAction<UpdateSelfLocationAction>(req);
    }

    protected override string GetEnvelopeReqName()
    {
        return "UpdateSelfLocationRequest";
    }

    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.UpdateSelfLocation;
    }

    protected override bool Receive(int errorCode, string errorMsg, UpdateSelfLocationResponse rsp, UpdateSelfLocationRequest req)
    {
        if (!base.Receive(errorCode, errorMsg, rsp, req))
        {
            MLog.Debug(eLogTag.entity, "main player req move error");
            return false;
        }

        return true;
    }
}