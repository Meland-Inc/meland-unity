using UnityGameFramework.Runtime;

/// <summary>
/// 日志标签 可以用来区分不同的日志 看业务层自己需要多细 公共的尽量定义前面一点
/// </summary>
public enum eLogTag
{
    unknown,
    network,
    scene,
    ui,
    login,
    runtime,
}

/// <summary>
/// meland自己的日志打印
/// </summary>
public static class MLog
{
    /// <summary>
    /// 装饰消息
    /// </summary>
    /// <param name="tag">日志tag</param>
    /// <param name="message">源日志消息</param>
    /// <returns></returns>
    private static string DecorateMessage(eLogTag tag, string message)
    {
        return $"<{tag}> {message}";
    }

    public static void Debug(eLogTag tag, string msg)
    {
        Log.Debug(DecorateMessage(tag, msg));
    }

    public static void Debug(eLogTag tag, object msg)
    {
        Log.Debug(DecorateMessage(tag, msg.ToString()));
    }

    public static void Info(eLogTag tag, string msg)
    {
        Log.Info(DecorateMessage(tag, msg));
    }

    public static void Info(eLogTag tag, object msg)
    {
        Log.Info(DecorateMessage(tag, msg.ToString()));
    }

    public static void Warning(eLogTag tag, string msg)
    {
        Log.Warning(DecorateMessage(tag, msg));
    }

    public static void Warning(eLogTag tag, object msg)
    {
        Log.Warning(DecorateMessage(tag, msg.ToString()));
    }

    public static void Error(eLogTag tag, string msg)
    {
        Log.Error(DecorateMessage(tag, msg));
    }

    public static void Error(eLogTag tag, object msg)
    {
        Log.Error(DecorateMessage(tag, msg.ToString()));
    }

    public static void Fatal(eLogTag tag, string msg)
    {
        Log.Fatal(DecorateMessage(tag, msg));
    }

    public static void Fatal(eLogTag tag, object msg)
    {
        Log.Fatal(DecorateMessage(tag, msg.ToString()));
    }
}