
using System.Collections.Generic;
using Bian;
using Google.Protobuf.Collections;

public class TaskModel : DataModelBase
{
    public List<TaskChainData> TaskChainList { get; private set; } = new();

    public void InitData(RepeatedField<TaskList> rawTaskChainDatas)
    {

        TaskChainList.Clear();
        for (int i = 0; i < rawTaskChainDatas.Count; i++)
        {
            TaskChainList.Add(new TaskChainData().UpdateData(rawTaskChainDatas[i]));
        }
        SceneModule.TaskMgr.OnUpdateTaskChainData.Invoke();
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