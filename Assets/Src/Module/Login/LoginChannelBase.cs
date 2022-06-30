
public abstract class LoginChannelBase : ILoginChannel
{
    public System.Action OnLoginSuccess { get; set; } = delegate { };
    public abstract LoginDefine.eLoginChannel Channel { get; }

    public virtual string Token { get; protected set; }
    public virtual string UserID { get; protected set; }
    public abstract void Start();
}