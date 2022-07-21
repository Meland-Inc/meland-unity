using System.Collections.Generic;
using MelandGame3;

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

    public enum eTaskButton
    {
        ABANDON,
        RECEIVE,
        SUBMIT,
        UPGRADE,
        ARRIVE,
        NONE,
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
        public string Icon;
        public string Decs;
        public int CurRate;
        public int MaxRate;
        public TaskOption Option;

    }


    // test code
    public const int TEST_R = 222;
    public const int TEST_C = 222;

}