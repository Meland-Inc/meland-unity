/*
 * @Author: xiang huan
 * @Date: 2022-05-28 11:04:31
 * @LastEditTime: 2022-05-30 22:22:33
 * @LastEditors: xiang huan
 * @Description: egret 消息数据定义
 * @FilePath: /meland-unity/Assets/Src/Framework/Egret/EgretMessageDefine.cs
 * 
 */

namespace Egret
{
    public class Message
    {
        public int SeqId;
        public int Type;
        public int ErrorCode;
        public string ErrorMsg;

    }

    public class LoginResponse : Message
    {
        public string UserId;
    }

    public class QuizAnswerRequest : Message
    {
        public int Row;
        public int Col;
    }

    public class QuizCreateRoomRequest : Message
    {
        public string RoomID;
    }

    public class QuizCreateFightRequest : Message
    {
        public string SessionID;
    }

    public class TWebViewEnableMode : Message
    {
        public int Mode;
        public bool Enable;
    }
}