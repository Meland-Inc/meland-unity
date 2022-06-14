using System;
using UnityEngine;
using UnityGameFramework.Runtime;

public class SigninPlayerAction : GameChannelNetMsgRActionBase<Bian.SigninPlayerRequest, Bian.SigninPlayerResponse>
{
    public static void Req(string playerID)
    {
        Bian.SigninPlayerRequest req = GenerateReq();
        req.PlayerId = playerID;
        req.ClientTime = Convert.ToInt32(Time.time);
        req.IsDeveloper = true;
        req.Chonglian = 0;
        SendAction<SigninPlayerAction>(req);
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
        BasicModule.LoginCenter.OnSignPlayer(rsp);
        return true;
    }
}