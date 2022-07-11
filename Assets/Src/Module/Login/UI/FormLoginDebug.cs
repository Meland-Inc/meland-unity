using System;
public class FormLoginDebug : FGUIForm
{
    private LoginChannelDebug _refLoginChannel;
    public Action<string> OnConfirmLogin = delegate { };
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        _refLoginChannel = userData as LoginChannelDebug;
        if (_refLoginChannel == null)
        {
            throw new Exception("LoginChannelDebug is null");
        }

        GCom.GetChild("btnLogin").onClick.Add(OnLoginClick);
    }

    private void OnLoginClick()
    {
        string userID = GCom.GetChild("inpUserID").text;
        if (userID.Length == 0)
        {
            return;
        }

        _refLoginChannel.ConfirmLogin(userID);
    }
}