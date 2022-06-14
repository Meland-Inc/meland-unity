using System;
public interface ILoginChannel
{
    LoginDefine.eLoginChannel Channel { get; }
    string Token { get; }
    string UserID { get; }
    Action OnLoginSuccess { get; set; }
    void Register(string account, string userName, string password);
    void LoginWithUserName(string username, string password);
    void LoginWithAccount(string account, string password);
    void LoginWithToken(string token);
    void Logout();
    void Start();
    void End();
}
