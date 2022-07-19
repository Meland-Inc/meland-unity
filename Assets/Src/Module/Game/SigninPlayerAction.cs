using System;
using UnityEngine;
using UnityGameFramework.Runtime;

public class SigninPlayerAction : GameChannelNetMsgRActionBase<MelandGame3.SigninPlayerRequest, MelandGame3.SigninPlayerResponse>
{
    public static SigninPlayerAction Req(string playerID)
    {
        MelandGame3.SigninPlayerRequest req = GenerateReq();
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

    protected override MelandGame3.EnvelopeType GetEnvelopeType()
    {
        return MelandGame3.EnvelopeType.SigninPlayer;
    }

    protected override bool Receive(int errorCode, string errorMsg, MelandGame3.SigninPlayerResponse rsp, MelandGame3.SigninPlayerRequest req)
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