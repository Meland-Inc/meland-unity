

using MelandGame3;
public class TaskAcceptAction : GameChannelNetMsgRActionBase<AcceptTaskRequest, AcceptTaskResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.AcceptTask;
    }

    protected override bool Receive(int errorCode, string errorMsg, AcceptTaskResponse rsp, AcceptTaskRequest req)
    {
        if (!base.Receive(errorCode, errorMsg, rsp, req))
        {
            _ = UICenter.OpenUIToast<ToastCommon>(errorMsg);
            return false;
        }

        DataManager.TaskModel.UpdateData(rsp.TaskListInfo);
        return true;
    }

    public static void Req(TaskListType taskListType)
    {
        AcceptTaskRequest req = GenerateReq();
        req.Kind = taskListType;
        _ = SendAction<TaskAcceptAction>(req);
    }
}
