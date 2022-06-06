/*
 * @Author: xiang huan
 * @Date: 2022-05-28 11:04:31
 * @LastEditTime: 2022-06-06 17:20:19
 * @LastEditors: xiang huan
 * @Description: runtime 相关定义
 * @FilePath: /meland-unity/Assets/Src/Framework/Runtime/RuntimeDefine.cs
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