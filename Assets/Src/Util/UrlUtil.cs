/// <summary>
/// 一些关于url处理的工具
/// </summary>
public static class UrlUtil
{
    /// <summary>
    /// 获取websocket使用的全链接
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public static string GetWebsocketFullUrl(string url)
    {
        if (string.IsNullOrEmpty(url))
        {
            return url;
        }

        string prefix;
#if DEBUG
        prefix = "ws";
#else
        prefix="wss";
#endif
        return $"{prefix}://{url}";
    }
}