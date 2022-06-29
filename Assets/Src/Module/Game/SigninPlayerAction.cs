using System;
using UnityEngine;
using UnityGameFramework.Runtime;

public class SigninPlayerAction : GameChannelNetMsgRActionBase<MelandGame3.SigninPlayerRequest, MelandGame3.SigninPlayerResponse>
{
    public static void Req(string playerID)
    {
        MelandGame3.SigninPlayerRequest req = GenerateReq();
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

    protected override MelandGame3.EnvelopeType GetEnvelopeType()
    {
        return MelandGame3.EnvelopeType.SigninPlayer;
    }

    protected override bool Receive(int errorCode, string errorMsg, MelandGame3.SigninPlayerResponse rsp, MelandGame3.SigninPlayerRequest req)
    {
        BasicModule.Login.OnSignPlayer(rsp);
        DataManager.MainPlayer.SetFeature(rsp.Player.Feature);
        return true;
    }
}