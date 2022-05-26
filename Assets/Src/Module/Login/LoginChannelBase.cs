public abstract class LoginChannelBase : ILoginChannel
{
    public abstract LoginDefine.eLoginChannel Channel { get; }

    public virtual string Token { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public virtual string UserID { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void CreatePlayer(string playerName)
    {
        throw new System.NotImplementedException();
    }

    public void GetPlayerInfo()
    {
        GetPlayersAction.Req();
    }

    public void LoginWithAccount(string account, string password)
    {
        throw new System.NotImplementedException();
    }

    public void LoginWithToken(string token)
    {
        //
    }

    public void LoginWithUserName(string username, string password)
    {
        throw new System.NotImplementedException();
    }

    public void Logout()
    {
        throw new System.NotImplementedException();
    }

    public void Register(string account, string userName, string password)
    {
        throw new System.NotImplementedException();
    }
}