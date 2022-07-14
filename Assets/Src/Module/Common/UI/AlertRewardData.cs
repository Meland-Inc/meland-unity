
using System;
using System.Collections.Generic;

public class AlertRewardData : AlertData
{
    public List<RewardNftData> Rewards;
    public AlertRewardData(string title = "",
                           string content = "",
                           string okBtnText = "",
                           Action oKBtnCb = null,
                           List<RewardNftData> rewards = null) : base(title, content, okBtnText, oKBtnCb)
    {
        Rewards = rewards;
    }
}