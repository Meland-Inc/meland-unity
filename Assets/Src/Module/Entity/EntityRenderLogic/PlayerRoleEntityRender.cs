using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家实体渲染逻辑
/// </summary>
public class PlayerRoleEntityRender : Avatar2DEntityRender
{
    protected override void ProcessAvatar()
    {
        Avatar2D = gameObject.AddComponent<Avatar2DMixed>();

        Avatar2DMixed mixed = Avatar2D as Avatar2DMixed;
        PlayerRoleAvatarData avatarData = RefSceneEntity.GetComponent<PlayerRoleAvatarData>();
        string skeletonRes = Avatar2DUtil.GetRoleSkeletonRes(avatarData.RoleCfgID);
        List<string> partList = Avatar2DUtil.GetPartResList(avatarData.RoleCfgID, NetUtil.SvrToClientRoleFeature(avatarData.Feature));

        mixed.LoadAvatar(skeletonRes, partList, (target) =>
        {
            RefSceneEntity.GetComponent<SpineAnimationCpt>().Init(Avatar2D.SkeletonAnimation);
        });
    }
}