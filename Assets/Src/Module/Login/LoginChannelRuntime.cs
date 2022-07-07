/*
 * @Author: mangit
 * @LastEditTime: 2022-07-07 10:22:28
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
        Runtime.LoginAction.Req().SetCB(OnRuntimeLoginSuccess);
    }

    private void OnRuntimeLoginSuccess(Runtime.LoginResponse rsp)
    {
        UserID = rsp.UserId;
        OnLoginSuccess.Invoke();
    }

    private string GetToken()
    {
        LoginAuthData data = LoginAuthData.Create();
        return $"{data.Token} {data.DataHash} {UserID} {data.TimeStamp}";
    }
}