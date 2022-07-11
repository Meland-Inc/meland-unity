/*
 * @Author: mangit
 * @LastEditTime: 2022-06-30 21:34:47
 * @LastEditors: mangit
 * @Description: runtime登录渠道
 * @Date: 2022-06-14 14:39:07
 * @FilePath: /Assets/Src/Module/Login/LoginChannelRuntime.cs
 */
public class LoginChannelRuntime : LoginChannelBase
{
    public override string Token => GetToken();
    public override LoginDefine.eLoginChannel Channel => LoginDefine.eLoginChannel.RUNTIME;

    public override void Start()
    {
        Runtime.LoginAction.Req();
        Runtime.LoginAction.OnLoginSuccess += OnRuntimeLoginSuccess;
    }

    private void OnRuntimeLoginSuccess(string userID)
    {
        UserID = userID;
        OnLoginSuccess.Invoke();
        Runtime.LoginAction.OnLoginSuccess -= OnRuntimeLoginSuccess;
    }

    private string GetToken()
    {
        LoginAuthData data = LoginAuthData.Create();
        return $"{data.Token} {data.DataHash} {UserID} {data.TimeStamp}";
    }
}