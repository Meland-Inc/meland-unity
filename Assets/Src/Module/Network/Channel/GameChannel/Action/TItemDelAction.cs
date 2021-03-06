using System;
using System.Security.Cryptography;
/*
 * @Author: mangit
 * @LastEditTime: 2022-06-30 23:04:05
 * @LastEditors: mangit
 * @Description: 
 * @Date: 2022-06-16 20:00:33
 * @FilePath: /Assets/Src/Module/Network/Channel/GameChannel/Action/TItemDelAction.cs
 */
using MelandGame3;
public class TItemDelAction : GameChannelNetMsgTActionBase<TItemDelResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.TitemDel;
    }

    protected override bool Receive(int errorCode, string errorMsg, TItemDelResponse rsp)
    {
        if (!base.Receive(errorCode, errorMsg, rsp))
        {
            return false;
        }

        string[] idList = new string[rsp.Items.Count];
        for (int i = 0; i < rsp.Items.Count; i++)
        {
            idList[i] = rsp.Items[i].Id;
        }
        DataManager.Backpack.RemoveData(idList);
        return true;
    }
}