/*
 * @Author: mangit
 * @LastEditTime: 2022-06-14 15:17:06
 * @LastEditors: mangit
 * @Description: runtime登录渠道
 * @Date: 2022-06-14 14:39:07
 * @FilePath: /Assets/Src/Module/Login/LoginChannelRuntime.cs
 */
public class LoginChannelRuntime : LoginChannelBase
{
    public override LoginDefine.eLoginChannel Channel => LoginDefine.eLoginChannel.RUNTIME;
    public override void Logout()
    {
        throw new System.NotImplementedException();
    }

    public override void Register(string account, string userName, string password)
    {
        throw new System.NotImplementedException();
    }

    public override void Start()
    {
        Runtime.LoginAction.Req();
        Runtime.LoginAction.OnLoginSuccess += OnRuntimeLoginSuccess;
    }

    public override void End()
    {
        Runtime.LoginAction.OnLoginSuccess -= OnRuntimeLoginSuccess;
    }

    private void OnRuntimeLoginSuccess(string userID)
    {
        UserID = userID;
        OnLoginSuccess.Invoke();
    }
}