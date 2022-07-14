
using System.Collections.Generic;
using Bian;
using Google.Protobuf.Collections;

public class TaskModel : DataModelBase
{
    public readonly List<TaskChainData> TaskChainList = new();

    public void InitData(RepeatedField<TaskList> rawTaskChainDatas)
    {

        TaskChainList.Clear();
        for (int i = 0; i < rawTaskChainDatas.Count; i++)
        {
            TaskChainList.Add(new TaskChainData().UpdateData(rawTaskChainDatas[i]));
        }
        SceneModule.TaskMgr.OnInitTaskChainData.Invoke();
    }

    public void UpdateData(TaskList rawTaskChainData)
    {

        TaskChainData chainData = TaskChainList.Find(chain => chain.TaskChainId == rawTaskChainData.Id);
        if (chainData != null)
        {
            _ = chainData.UpdateData(rawTaskChainData);
        }
        else
        {
            TaskChainList.Add(new TaskChainData().UpdateData(rawTaskChainData));
        }

        SceneModule.TaskMgr.OnUpdateTaskChainData.Invoke();
    }
}