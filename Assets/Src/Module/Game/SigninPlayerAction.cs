using System;
using UnityEngine;
using UnityGameFramework.Runtime;

public class SigninPlayerAction : GameChannelNetMsgRActionBase<Bian.SigninPlayerRequest, Bian.SigninPlayerResponse>
{
    public static SigninPlayerAction Req(string playerID)
    {
        Bian.SigninPlayerRequest req = GenerateReq();
        req.PlayerId = playerID;
        req.ClientTime = Convert.ToInt32(Time.time);
        req.IsDeveloper = true;
        req.Chonglian = 0;
        return SendAction<SigninPlayerAction>(req);
    }

    protected override string GetEnvelopeReqName()
    {
        return "SigninPlayerRequest";
    }

    protected override Bian.EnvelopeType GetEnvelopeType()
    {
        return Bian.EnvelopeType.SigninPlayer;
    }

    protected override bool Receive(int errorCode, string errorMsg, Bian.SigninPlayerResponse rsp, Bian.SigninPlayerRequest req)
    {
        if (!base.Receive(errorCode, errorMsg, rsp, req))
        {
            return false;
        }

        DataManager.MainPlayer.InitRoleData(rsp.Player);//这里可能没有player的战斗数据，enterMap的时候会有完整的过来
        BasicModule.Login.OnSignPlayer(rsp);
        return true;
    }
}