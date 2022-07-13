using System.Collections.Generic;
using System.Net.Http;
using HttpPacketDefine;
using MelandGame3;
using UnityEngine;
using RoleDefine;
using System;
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
            BasicModule.Login.OnRoleReady.Invoke(rsp.Info.Id);
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
            shoes = features[eRoleFeaturePart.shoes],
        };
        req.feature = JsonUtility.ToJson(playerFeature);
        req.osType = (int)OSType.OstypeMac;//todo:
        SendAction<CreateRoleAction>(req);
    }
}

public class CreatePlayerReq
{
    public int roleId;
    public string name;
    public string gender;
    public string feature;
    public int osType;
    public int platform;
    public string roleIcon;

}

[Serializable]
public class CreatePlayerRspInfo
{
    public string Id;
    public string Gender;
    public string Name;
    public string RoleIcon;
    public string RoleId;
    public string Feature;
}

[Serializable]
public class RoleFeature
{
    public int hair;
    public int clothes;
    public int glove;
    public int pants;
    public int face;
    // public int eye;
    // public int mouth;
    // public int eyebrow;
    public int shoes;
}