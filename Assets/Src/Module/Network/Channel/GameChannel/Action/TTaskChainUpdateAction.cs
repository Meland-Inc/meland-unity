


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
            _ = UICenter.OpenUIToast<ToastCommon>(errorMsg);
            return false;
        }
        if (rsp.TaskListInfo == null)
        {
            DataManager.TaskModel.RemoveData(rsp.Kind);
            return true;
        }
        DataManager.TaskModel.UpdateData(rsp.TaskListInfo);

        return true;
    }
}