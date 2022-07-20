

using System;
using System.Collections.Generic;
using Bian;
using UnityEngine;

public class TaskMgr : MonoBehaviour
{
    public Action OnTaskAccept = delegate { };
    public Action OnUpdateTaskChainData = delegate { };
    public Action OnInitTaskChainData = delegate { };

    private void Awake()
    {
        // ReqData();
        Message.RuntimeQuizAnswerResult += OnRuntimeQuizAnswerResult;
        Message.RspMapEnterFinish += OnMapEnterFinish;
        // Message.OnReconnect += OnReconnect;
    }

    private void OnDestroy()
    {
        Message.RuntimeQuizAnswerResult -= OnRuntimeQuizAnswerResult;
        Message.RspMapEnterFinish -= OnMapEnterFinish;
        // Message.OnReconnect -= OnReconnect;
    }

    private void OnMapEnterFinish(EnterMapResponse obj)
    {
        ReqData();
    }

    public void ReqData()
    {
        TaskChainGetAction.Req();
    }

    private void OnRuntimeQuizAnswerResult(Runtime.TQuizAnswerResultResponse rsp)
    {
        // 答题不正确
        if (!rsp.Result)
        {
            return;
        }

        List<TaskChainData> taskChainList = DataManager.TaskModel.TaskChainList;
        // 没有任务链
        if (taskChainList.Count <= 0)
        {
            return;
        }

        taskChainList.ForEach(taskChian =>
        {
            // 没领取任务
            if (taskChian.CurTask == null)
            {
                return;
            }

            List<TaskDefine.TaskSubItemData> curTaskObjectives = taskChian.CurTaskSubItems;
            for (int i = 0; i < curTaskObjectives.Count; i++)
            {
                TaskDefine.TaskSubItemData objectData = curTaskObjectives[i];
                TaskOptionCnf optionCfg = objectData.Option.OptionCnf;
                // 答题任务，且答题类型一致
                if (optionCfg.DataCase == TaskOptionCnf.DataOneofCase.QuizInfo && optionCfg.QuizInfo.QuizType == rsp.QuizId)
                {
                    TaskUpgradeTaskProgressAction.ReqQuiz(taskChian.TaskChainKind, optionCfg.QuizInfo.QuizType);
                    break;
                }
            }
        });
    }

    public void OpenTask(TaskChainData chainData = null)
    {
        ReqData();
        _ = UICenter.OpenUIForm<FormTask>(chainData);
    }

    public void OpenTaskSubmit(TaskChainData taskChainData)
    {
        _ = UICenter.OpenUIForm<FormTaskSubmit>(taskChainData);
    }

}