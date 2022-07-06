/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: toast 提示数据
 * @Date: 2022-07-06 09:53:51
 * @FilePath: /Assets/Src/Framework/UI/Data/ToastInfo.cs
 */
public class ToastData
{
    public string Text { get; private set; }
    public ToastData(string text)
    {
        Text = text;
    }
}