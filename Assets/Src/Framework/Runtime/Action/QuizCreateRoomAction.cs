/*
 * @Author: xiang huan
 * @Date: 2022-05-28 19:45:03
 * @LastEditTime: 2022-06-06 17:19:35
 * @LastEditors: xiang huan
 * @Description: 请求创建房间
 * @FilePath: /meland-unity/Assets/Src/Framework/Runtime/Action/QuizCreateRoomAction.cs
 * 
 */

namespace Runtime
{
    public class QuizCreateRoomAction : RuntimeMsgRActionBase<QuizCreateRoomRequest, RuntimeMessage>
    {
        public static void Req(string roomId)
        {
            QuizCreateRoomRequest req = GenerateReq();
            req.RoomID = roomId;
            SendAction<QuizCreateRoomAction>(req);
        }

        protected override RuntimeDefine.eRuntimeEnvelopeType GetEnvelopeType()
        {
            return RuntimeDefine.eRuntimeEnvelopeType.QuizCreateRoom;
        }

        protected override bool Receive(int errorCode, string errorMsg, RuntimeMessage rsp, QuizCreateRoomRequest req)
        {
            if (errorCode != RuntimeDefine.SUCCESS_CODE)
            {
                return false;
            }
            return true;
        }
    }

    public class QuizCreateRoomRequest : RuntimeMessage
    {
        public string RoomID;
    }

}