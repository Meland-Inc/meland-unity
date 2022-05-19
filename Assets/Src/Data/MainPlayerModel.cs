using UnityEngine;

/// <summary>
/// 自己玩家数据
/// </summary>
public class MainPlayerModel : DataModelBase
{
    [SerializeField]
    private string _roleID;
    /// <summary>
    /// 角色ID 也是场景实体ID
    /// </summary>
    public string RoleID => _roleID;

    /// <summary>
    /// 账号和登陆相关数据 不为null
    /// </summary>
    /// <value></value>
    public AccountData AccountData { get; private set; }

    /// <summary>
    /// 场景中的主角色 角色数据从这个上面拿 可能为null
    /// </summary>
    public SceneEntity MainPlayerRole { get; private set; }

    public void Awake()
    {
        AccountData = gameObject.AddComponent<AccountData>();
    }

    /// <summary>
    /// 初始化角色数据
    /// </summary>
    /// <param name="roleID"></param>
    public void InitRoleData(string roleID)
    {
        _roleID = roleID;
    }

    /// <summary>
    /// 设置场景中的主角色 角色数据都从这个上面拿
    /// </summary>
    /// <param name="role"></param>
    public void SetMainPlayerRole(SceneEntity role)
    {
        MainPlayerRole = role;
    }
}