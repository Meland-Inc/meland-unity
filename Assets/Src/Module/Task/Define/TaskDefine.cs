using System.Collections.Generic;
using Bian;

public static class TaskDefine
{
    // 悬赏任务最大进度
    public const int REWARD_MAX_RATE = 100;
    // 每日任务最大进度
    public const int DAILY_MAX_RATE = 10;
    public enum eTaskState
    {
        UNSTART,
        ONDOING,
        FINISH
    }

    public enum eTaskChainState
    {
        NONE,
        AVAILABLE,
        HADRECEIVE,
        ONDOING,
    }

    public static Dictionary<int, string> TaskSystemId2Name = new()
    {
         {1, "Daily Quest"},
         { 2,"Mission Reward"}
    };

    public static Dictionary<int, string> TaskQuizId2Name = new()
    {
        {1,"AdjustClock"},
        {2,"BlockCompute"},
        {3,"CageShuffle"},
        {4,"CardMemory"},
        {5,"CuttingArt"},
        {6,"HitBrick"},
        {7,"MatchingMouse"},
        {8,"QuickFlashMemory"},
        {9,"ReverseMemory"},
        {10,"RotatingSilhouette"},
        {11,"SequenceBalloon"},
    };

    public class TaskSubItemData
    {
        public string Decs;
        public int CurRate;
        public int MaxRate;
        public TaskOption Option;

    }

    // public class TaskBpItemData
    // {
    //     public BpItemData ItemData;
    //     public int Count;
    // }


}