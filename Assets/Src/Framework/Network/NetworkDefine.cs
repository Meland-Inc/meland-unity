using System;
using System.Collections.Generic;
using System.Net.Http;
/// <summary>
/// 网络相关的一些定义
/// </summary>
public static class NetworkDefine
{
    public const string CHANNEL_NAME_GAME = "game";
    public const string CHANEL_NAME_HTTP = "http";
    public const string CHANEL_NAME_RUNTIME = "runtime";
    // 心跳间隔 s
    public const int CHANEL_HEART_BRAT_INTERVAL = 30;

    // 序列号id 从1开始
    public const int CHANEL_MIN_SEQ_ID = 1;
}