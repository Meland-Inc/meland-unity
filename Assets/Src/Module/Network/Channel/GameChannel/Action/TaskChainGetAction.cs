
using Bian;
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
            return false;
        }
        DataManager.TaskModel.InitData(rsp.Tasks.TaskLists);
        return true;
    }

    public static void Req()
    {
        SelfTasksRequest req = GenerateReq();
        SendAction<TaskChainGetAction>(req);
    }
}
