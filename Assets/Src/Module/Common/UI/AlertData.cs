/*
 * @Author: mangit
 * @LastEditors: wym
 * @Description: 
 * @Date: 2022-07-04 17:26:23
 * @FilePath: /Assets/Src/Module/Common/UI/AlertData.cs
 */

// public delegate void OKBtnCb();
using System;

public class AlertData
{
    public string Title { get; private set; }
    public string Content { get; private set; }
    public string OKBtnText { get; private set; }
    public Action OKBtnCb = delegate { };

    public AlertData(string title = "", string content = "", string okBtnText = "", Action oKBtnCb = null)
    {
        Title = title;
        Content = content;
        OKBtnText = okBtnText;
        if (oKBtnCb != null)
        {
            OKBtnCb += oKBtnCb;
        }

    }
}