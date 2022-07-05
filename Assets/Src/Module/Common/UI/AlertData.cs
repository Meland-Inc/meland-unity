/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 
 * @Date: 2022-07-04 17:26:23
 * @FilePath: /Assets/Src/Module/Common/UI/AlertData.cs
 */
public class AlertData
{

    public string Title { get; private set; }
    public string Content { get; private set; }
    public string OKBtnText { get; private set; }

    public AlertData(string title = "", string content = "", string okBtnText = "")
    {
        Title = title;
        Content = content;
        OKBtnText = okBtnText;
    }
}