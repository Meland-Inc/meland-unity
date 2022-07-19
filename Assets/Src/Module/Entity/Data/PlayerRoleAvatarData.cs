using UnityEngine;

/// <summary>
/// 玩家角色身上的avatar数据
/// </summary>
public class PlayerRoleAvatarData : MonoBehaviour
{
    /// <summary>
    /// 角色配置ID
    /// </summary>
    /// <value></value>
    public int RoleCfgID { get; private set; }
    /// <summary>
    /// 角色外观数据
    /// </summary>
    /// <value></value>
    public MelandGame3.PlayerFeature Feature { get; private set; }

    public void SetRoleCfgID(int roleCfgID)
    {
        RoleCfgID = roleCfgID;
    }

    public void SetRoleFeature(MelandGame3.PlayerFeature feature)
    {
        Feature = feature;
    }
}