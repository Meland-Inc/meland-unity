/*
 * @Author: xiang huan
 * @Date: 2022-05-28 11:04:31
 * @Description: runtime 相关定义
 * @FilePath: /Assets/Src/Framework/Runtime/RuntimeDefine.cs
 * 
 */

public sealed class RuntimeDefine
{

    public const int SUCCESS_CODE = 0;

    public enum eRuntimeEnvelopeType
    {
        Login = 1000,
        WebReady = 1001,
        QuizAnswer = 1002,
        QuizCreateRoom = 1003,
        QuizCreateFight = 1004,
        TWebViewEnableMode = 1005,
        TUserAsset = 1006,

        GetUnlockedRecipes = 2001,
        UseRecipes = 2002,
        GetUserSkillInfo = 2003,
        RechargeToken = 2004,
        TRechargeTokenSuccess = 2005,
        GetUserGameInternalToken = 2006,
        UpgradeSkill = 2007,
        TQuizAnswerResult = 1007,
    };

    public enum eEgretEnableMode
    {
        Login = 1000,
        QuizRoom = 1001,
        QuizAnswer = 1002,
        QuizAnswerSettlement = 1003,
        QuizPVP = 1004,
    }


}