/// <summary>
/// 网络相关的一些定义
/// </summary>
public sealed class NetworkDefine
{
    public const string CHANNEL_NAME_GAME = "game";
    // 心跳间隔 s
    public const int CHANEL_HEART_BRAT_INTERVAL = 30;

    // 为了与 Bian.envelopType 区分开，从 10W + 开始计数
    public const int CHANEL_RANDOM_MIN_SEQ_ID = 100001;
    public const int CHANEL_RANDOM_MAX_SEQ_ID = 101000;

}