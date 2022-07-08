/*
 * @Author: mangit
 * @LastEditTime: 2022-07-07 19:55:59
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
        MLog.Info(eLogTag.login, "start login channel runtime");
        Runtime.LoginAction.Req().SetCB(OnRuntimeLoginSuccess);
    }

    private void OnRuntimeLoginSuccess(Runtime.LoginResponse rsp)
    {
        MLog.Info(eLogTag.login, $"runtime login success,userId:{rsp.UserId}");
        UserID = rsp.UserId;
        OnLoginSuccess.Invoke();
    }

    private string GetToken()
    {
        LoginAuthData data = LoginAuthData.Create();
        return $"{data.Token} {data.DataHash} {UserID} {data.TimeStamp}";
    }
}