using System;
public interface ILoginChannel
{
    LoginDefine.eLoginChannel Channel { get; }
    string Token { get; }
    string UserID { get; }
    Action OnLoginSuccess { get; set; }
    void Start();
}
