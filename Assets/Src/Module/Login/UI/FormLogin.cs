public class FormLogin : FGUIForm
{
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        GCom.GetChild("btnLogin").onClick.Add(OnLoginClick);
    }

    private void OnLoginClick()
    {
        string userID = GCom.GetChild("inpUserID").text;
        if (userID.Length == 0)
        {
            return;
        }
        BasicModule.LoginCenter.SetUserID(userID);
        BasicModule.LoginCenter.ConnectGameServer();
    }
}
