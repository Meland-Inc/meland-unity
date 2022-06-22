using UnityEngine;
using Bian;

/// <summary>
/// 自己玩家数据
/// </summary>
public class MainPlayerModel : DataModelBase
{
    [SerializeField]
    private Player _roleData;
    public Player RoleData => _roleData;
    /// <summary>
    /// 角色ID 也是场景实体ID
    /// </summary>
    public string RoleID => _roleData.Id;

    /// <summary>
    /// 账号和登陆相关数据 不为null
    /// </summary>
    /// <value></value>
    public AccountData AccountData { get; private set; }

    /// <summary>
    /// 场景中的主角色 角色数据从这个上面拿 可能为null
    /// </summary>
    public SceneEntity Role { get; private set; }

    public void Awake()
    {
        AccountData = new AccountData();
    }

    /// <summary>
    /// 初始化角色的数据 不管有没有场景角色 纯数据
    /// </summary>
    /// <param name="roleData"></param>
    public void InitRoleData(Player roleData)
    {
        _roleData = roleData;
    }

    /// <summary>
    /// 设置场景中的主角色 角色数据都从这个上面拿
    /// </summary>
    /// <param name="role"></param>
    public void SetRole(SceneEntity role)
    {
        Role = role;
    }
}