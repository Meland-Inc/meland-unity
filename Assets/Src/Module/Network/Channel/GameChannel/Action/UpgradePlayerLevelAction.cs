using System.Net.Http.Headers;
/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 请求角色升级
 * @Date: 2022-06-23 14:24:58
 * @FilePath: /Assets/Src/Module/Network/Channel/GameChannel/Action/UpgradePlayerLevelAction.cs
 */
using Bian;

public class UpgradePlayerLevelAction : GameChannelNetMsgRActionBase<UpgradePlayerLevelRequest, UpgradePlayerLevelResponse>
{
    protected override EnvelopeType GetEnvelopeType()
    {
        return EnvelopeType.UpgradePlayerLevel;
    }

    protected override bool Receive(int errorCode, string errorMsg, UpgradePlayerLevelResponse rsp, UpgradePlayerLevelRequest req)
    {
        if (!base.Receive(errorCode, errorMsg, rsp, req))
        {
            return false;
        }

        return true;
    }
}