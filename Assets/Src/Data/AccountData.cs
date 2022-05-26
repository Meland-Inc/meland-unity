using UnityEngine;

/// <summary>
/// 账号和登陆相关数据
/// </summary>
public class AccountData : MonoBehaviour
{
    [SerializeField]
    private string _account;

    public string Account { get => _account; set => _account = value; }
}