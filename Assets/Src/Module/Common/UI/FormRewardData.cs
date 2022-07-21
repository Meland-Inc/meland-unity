
using System;
using System.Collections.Generic;

public class FormRewardData
{
    public string Title { get; private set; }
    public string Content { get; private set; }
    public string OKBtnText { get; private set; }
    public Action OKBtnCb = delegate { };
    public List<RewardNftData> Rewards;
    public FormRewardData(string title = "",
                           string content = "",
                           string okBtnText = "",
                           Action oKBtnCb = null,
                           List<RewardNftData> rewards = null)
    {
        Title = title;
        Content = content;
        OKBtnText = okBtnText;
        if (oKBtnCb != null)
        {
            OKBtnCb += oKBtnCb;
        }
        Rewards = rewards;
    }
}