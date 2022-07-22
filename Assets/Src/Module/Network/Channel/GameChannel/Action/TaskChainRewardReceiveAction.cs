

using MelandGame3;
public class TaskChainRewardReceiveAction : GameChannelNetMsgRActionBase<TaskListRewardRequest, TaskListRewardResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.TaskListReward;
    }

    protected override bool Receive(int errorCode, string errorMsg, TaskListRewardResponse rsp, TaskListRewardRequest req)
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
        TaskListRewardRequest req = GenerateReq();
        req.Kind = taskListType;
        SendAction<TaskChainRewardReceiveAction>(req);
    }
}
