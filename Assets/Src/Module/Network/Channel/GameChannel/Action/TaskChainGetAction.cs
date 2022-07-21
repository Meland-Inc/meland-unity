
using MelandGame3;
public class TaskChainGetAction : GameChannelNetMsgRActionBase<SelfTasksRequest, SelfTasksResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.SelfTasks;
    }

    protected override bool Receive(int errorCode, string errorMsg, SelfTasksResponse rsp, SelfTasksRequest req)
    {
        if (!base.Receive(errorCode, errorMsg, rsp, req))
        {
            _ = UICenter.OpenUIToast<ToastCommon>(errorMsg);
            return false;
        }
        if (rsp == null)
        {
            _ = UICenter.OpenUIToast<ToastCommon>("Server error, could not get the task");
            return false;
        }
        DataManager.TaskModel.InitData(rsp.Tasks.TaskLists);
        return true;
    }

    public static void Req()
    {
        SelfTasksRequest req = GenerateReq();
        _ = SendAction<TaskChainGetAction>(req);
    }
}
