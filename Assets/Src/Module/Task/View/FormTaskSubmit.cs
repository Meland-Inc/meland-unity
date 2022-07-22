


public class FormTaskSubmit : FGUIForm
{

    private TaskSubmitViewLogic _taskSubmitViewLogic;
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        _taskSubmitViewLogic = GCom.AddSubUILogic<TaskSubmitViewLogic>("comTaskSubmit");
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        _taskSubmitViewLogic.SetData(userData as TaskChainData);
    }

    protected override void OnClose(bool isShutdown, object userData)
    {
        base.OnClose(isShutdown, userData);
    }
}