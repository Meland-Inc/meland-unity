public interface ILoginChannel
{
    LoginDefine.eLoginChannel Channel { get; }
    string Token { get; set; }
    string UserID { get; set; }
    void Register(string account, string userName, string password);
    void LoginWithUserName(string username, string password);
    void LoginWithAccount(string account, string password);
    void LoginWithToken(string token);
    void Logout();
    void GetPlayerInfo();
    void CreatePlayer(string playerName);
}
