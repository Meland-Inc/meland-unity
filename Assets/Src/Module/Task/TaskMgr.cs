

using System;
using System.Collections.Generic;
using Bian;
using UnityEngine;

public class TaskMgr : MonoBehaviour
{
    public Action OnTaskAccept = delegate { };
    public Action OnUpdateTaskChainData = delegate { };

    private void Awake()
    {
        // ReqData();
        Message.RuntimeQuizAnswerResult += OnRuntimeQuizAnswerResult;
    }

    private void OnDestroy()
    {
        Message.RuntimeQuizAnswerResult -= OnRuntimeQuizAnswerResult;
    }

    private void OnRuntimeQuizAnswerResult(Runtime.TQuizAnswerResultResponse rsp)
    {
        List<TaskChainData> taskChainList = DataManager.TaskModel.TaskChainList;
        if (taskChainList == null || taskChainList.Count <= 0)
        {
            return;
        }

        taskChainList.ForEach(taskChian =>
        {
            if (taskChian.CurTask == null)
            {
                return;
            }

            List<TaskDefine.TaskObjectData> curTaskObjectives = taskChian.CurTaskObjectives;
            for (int i = 0; i < curTaskObjectives.Count; i++)
            {
                TaskDefine.TaskObjectData objectData = curTaskObjectives[i];
                TaskOptionCnf optionCfg = objectData.Option.OptionCnf;
                if (optionCfg.DataCase == TaskOptionCnf.DataOneofCase.QuizInfo)
                {
                    TaskUpgradeTaskProgressAction.ReqQuiz(taskChian.TaskChainKind, optionCfg.QuizInfo.QuizNum);
                    break;
                }
            }
        });
    }

    public void OpenTask()
    {
        // ReqData();
        _ = UICenter.OpenUIForm<FormTask>();
    }

    public void OpenTaskSubmit(TaskChainData taskChainData)
    {
        // ReqData();
        _ = UICenter.OpenUIForm<FormTaskSubmit>(taskChainData);
    }
}