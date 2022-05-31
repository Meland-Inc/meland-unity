using System.Text.RegularExpressions;
/*
 * @Author: xiang huan
 * @Date: 2022-05-28 11:04:31
 * @LastEditTime: 2022-05-30 22:15:16
 * @LastEditors: xiang huan
 * @Description: egret 相关定义
 * @FilePath: /meland-unity/Assets/Src/Framework/Egret/EgretDefine.cs
 * 
 */

public sealed class EgretDefine
{

    // 序列号id 从1开始
    public const int EGRET_MIN_SEQ_ID = 1;
    public const int SUCCESS_CODE = 0;

    public enum eEgretEnvelopeType
    {
        Login = 1000,
        EgretReady = 1001,
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