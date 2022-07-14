
using Bian;
public class TaskRewardReceiveAction : GameChannelNetMsgRActionBase<TaskRewardRequest, TaskRewardResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.TaskReward;
    }

    protected override bool Receive(int errorCode, string errorMsg, TaskRewardResponse rsp, TaskRewardRequest req)
    {
        if (!base.Receive(errorCode, errorMsg, rsp, req))
        {
            return false;
        }
        DataManager.TaskModel.UpdateData(rsp.TaskListInfo);
        return true;
    }

    public static void Req(TaskListType taskListType)
    {
        TaskRewardRequest req = GenerateReq();
        req.TaskListKind = taskListType;
        SendAction<TaskRewardReceiveAction>(req);
    }
}
