
using System.Collections.Generic;
using MelandGame3;

public class TaskUpgradeTaskProgressAction : GameChannelNetMsgRActionBase<UpgradeTaskProgressRequest, UpgradeTaskProgressResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.UpgradeTaskProgress;
    }

    protected override bool Receive(int errorCode, string errorMsg, UpgradeTaskProgressResponse rsp, UpgradeTaskProgressRequest req)
    {
        if (!base.Receive(errorCode, errorMsg, rsp, req))
        {
            _ = UICenter.OpenUIToast<ToastCommon>(errorMsg);
            return false;
        }
        // DataManager.TaskModel.UpdateData(rsp.TaskListInfo);
        return true;
    }

    public static void ReqItem(TaskListType taskListType, List<RewardNftData> submitIems)
    {
        UpgradeTaskProgressRequest req = GenerateReq();
        req.TaskListKind = taskListType;
        for (int i = 0; i < submitIems.Count; i++)
        {
            RewardNftData submitIem = submitIems[i];
            req.Items.Add(
                new TaskOptionItem()
                {
                    ItemCid = submitIem.Cid,
                    Num = submitIem.Count,
                    NftId = submitIem.NftId
                });
        }

        _ = SendAction<TaskUpgradeTaskProgressAction>(req);
    }

    public static void ReqQuiz(TaskListType taskListType, int quizType)
    {
        UpgradeTaskProgressRequest req = GenerateReq();
        req.TaskListKind = taskListType;
        req.Quiz.QuizType = quizType;
        req.Quiz.QuizNum = 1;
        _ = SendAction<TaskUpgradeTaskProgressAction>(req);
    }

    // public static void ReqPos(TaskListType taskListType, int r, int c)
    // {
    //     UpgradeTaskProgressRequest req = GenerateReq();
    //     req.TaskListKind = taskListType;
    //     req.Pos = new TaskOptionMoveTo
    //     {
    //         R = r,
    //         C = c
    //     };
    //     _ = SendAction<TaskUpgradeTaskProgressAction>(req);
    // }
}
