


using MelandGame3;
public class TTaskChainUpdateAction : GameChannelNetMsgTActionBase<TUpdateTaskListResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.TupdateTaskList;
    }

    protected override bool Receive(int errorCode, string errorMsg, TUpdateTaskListResponse rsp)
    {
        if (!base.Receive(errorCode, errorMsg, rsp))
        {
            return false;
        }
        DataManager.TaskModel.UpdateData(rsp.TaskListInfo);

        return true;
    }
}