


using System.Text.RegularExpressions;

public static class StringUtil
{
    /// <summary>
    /// 按顺序替换字符串中的%%
    /// </summary>
    /// <param name="orginStr"></param>
    /// <param name="strParams"></param>
    /// <returns></returns>
    public static string ReplaceTemplate(string orginStr, params string[] strParams)
    {
        Regex regex = new(Regex.Escape("%%"));
        for (int i = 0; i < strParams.Length; i++)
        {
            orginStr = regex.Replace(orginStr, strParams[i], 1);
        }
        return orginStr;
    }
}