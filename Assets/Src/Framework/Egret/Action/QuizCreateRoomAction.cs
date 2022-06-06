/*
 * @Author: xiang huan
 * @Date: 2022-05-28 19:45:03
 * @LastEditTime: 2022-06-06 14:43:45
 * @LastEditors: xiang huan
 * @Description: 请求创建房间
 * @FilePath: /meland-unity/Assets/Src/Framework/Egret/Action/QuizCreateRoomAction.cs
 * 
 */

namespace Egret
{
    public class QuizCreateRoomAction : EgretMsgRActionBase<QuizCreateRoomRequest, EgretMessage>
    {
        public static void Req(string roomId)
        {
            QuizCreateRoomRequest req = GenerateReq();
            req.RoomID = roomId;
            SendAction<QuizCreateRoomAction>(req);
        }

        protected override EgretDefine.eEgretEnvelopeType GetEnvelopeType()
        {
            return EgretDefine.eEgretEnvelopeType.QuizCreateRoom;
        }

        protected override bool Receive(int errorCode, string errorMsg, EgretMessage rsp, QuizCreateRoomRequest req)
        {
            if (errorCode != EgretDefine.SUCCESS_CODE)
            {
                return false;
            }
            return true;
        }
    }

    public class QuizCreateRoomRequest : EgretMessage
    {
        public string RoomID;
    }

}