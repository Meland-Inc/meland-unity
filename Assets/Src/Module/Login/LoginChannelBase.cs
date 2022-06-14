
public abstract class LoginChannelBase : ILoginChannel
{
    public abstract LoginDefine.eLoginChannel Channel { get; }

    public virtual string Token { get; protected set; }
    public virtual string UserID { get; protected set; }
    public System.Action OnLoginSuccess { get; set; } = delegate { };
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

    public abstract void Logout();

    public abstract void Register(string account, string userName, string password);

    public abstract void Start();
    public abstract void End();
}