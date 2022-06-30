using MelandGame3;

/// <summary>
/// 主角移动请求
/// </summary>
public class UpdateSelfLocationAction : GameChannelNetMsgRActionBase<UpdateSelfLocationRequest, UpdateSelfLocationResponse>
{
    /// <summary>
    /// </summary>
    /// <param name="curPos">当前世界坐标</param>
    public static void Req(UnityEngine.Vector3 curPos, UnityEngine.Vector3 dir, MovementType movementType, float speed, float targetTime)
    {
        UpdateSelfLocationRequest req = GenerateReq();
        req.Movement = new()
        {
            EntityId = DataManager.MainPlayer.RoleID,
            EntityType = EntityType.EntityTypePlayer,
            CurLocation = new()
            {
                Location = NetUtil.ClientToSvrLoc(curPos),
                Stamp = TimeUtil.GetTimeStamp(),
            },
            DestLocation = null,
            Type = movementType,
            Dir = NetUtil.ClientToSvrDir(dir)
        };
        if (!speed.ApproximatelyEquals(0))
        {
            UnityEngine.Vector3 targetPos = (speed * targetTime * dir.normalized) + curPos;
            req.Movement.DestLocation = new()
            {
                Location = NetUtil.ClientToSvrLoc(targetPos),
                Stamp = req.Movement.CurLocation.Stamp + (long)(targetTime * TimeDefine.S_2_MS)
            };
        }
        MLog.Debug(eLogTag.move, $"req move ={req.Movement}");
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