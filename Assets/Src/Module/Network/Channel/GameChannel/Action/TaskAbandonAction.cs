

using MelandGame3;
public class TaskAbandonAction : GameChannelNetMsgRActionBase<AbandonmentTaskRequest, AbandonmentTaskResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.AbandonmentTask;
    }

    protected override bool Receive(int errorCode, string errorMsg, AbandonmentTaskResponse rsp, AbandonmentTaskRequest req)
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
        AbandonmentTaskRequest req = GenerateReq();
        req.Kind = taskListType;
        _ = SendAction<TaskAbandonAction>(req);
    }
}
