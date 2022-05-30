/*
 * @Author: xiang huan
 * @Date: 2022-05-28 11:04:31
 * @LastEditTime: 2022-05-28 20:12:22
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
    }

    public class LoginResponse : Message
    {
        public string UserId;
    }
}