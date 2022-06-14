using System.Reflection;
using System.Collections.Generic;
using System.Net.Http;
using HttpPacketDefine;
using Bian;
using UnityEngine;
using RoleDefine;

public class CreateRoleAction : AccountHttpActionBase<CreatePlayerReq, AccountRsp<CreatePlayerRspInfo>>
{
    protected override string Api => "createplayer";
    protected override HttpMethod Method => HttpMethod.Post;
    protected override void Receive(AccountRsp<CreatePlayerRspInfo> rsp, CreatePlayerReq req)
    {
        if (rsp.Code == 403)
        {
            //处理创角失败
            return;
        }

        if (rsp.Code == 0)
        {
            //创角成功
            BasicModule.LoginCenter.OnRoleReady.Invoke(rsp.Info.Id);
        }
    }

    public static void Req(int roleID, string name, string roleIcon, string gender, Dictionary<eRoleFeaturePart, int> features)
    {
        CreatePlayerReq req = GenerateReq();
        req.roleId = roleID;
        req.name = name;
        req.roleIcon = roleIcon;
        req.gender = gender;
        RoleFeature playerFeature = new()
        {
            hair = features[eRoleFeaturePart.hair],
            clothes = features[eRoleFeaturePart.clothes],
            glove = features[eRoleFeaturePart.glove],
            pants = features[eRoleFeaturePart.pants],
            face = features[eRoleFeaturePart.face],
            // eye = features[i++],
            // mouth = features[i++],
            // eyebrow = features[i++],
            shoes = features[eRoleFeaturePart.shoes],
        };
        req.feature = JsonUtility.ToJson(playerFeature, true);
        req.osType = (int)OSType.OstypeMac;//todo:
        SendAction<CreateRoleAction>(req);
    }
}