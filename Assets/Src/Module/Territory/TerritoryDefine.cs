/*
 * @Author: xiang huan
 * @Date: 2022-06-16 14:17:21
 * @Description: 领地定义
 * @FilePath: /meland-unity/Assets/Src/Module/Territory/TerritoryDefine.cs
 * 
 */

public static class TerritoryDefine
{
    public static readonly int CHUNK_WIDTH = 32;
    public static readonly int CHUNK_HEIGHT = 32;
    public static readonly int BIG_WORLD_TOUCH_RANGE = 5; //点击范围
    public static readonly string WORLD_SYSTEM_BORDER_AREA_UID = "WORLD_SYSTEM_BORDER_AREA_UID"; //官方区域边界渲染uid

    public static readonly string WALLET_DEFAULT_ADDRESS = "N/A"; //钱包默认地址

    public static readonly int WORLD_SYSTEM_OWNER_ID = 0; //系统用户ID
    public static readonly int BIG_WORLD_OFFICIAL_BORDER_COLOR = 0xfaff2d;
    public static readonly int BIG_WORLD_MAIN_PLAYER_BORDER_COLOR = 0x43fffb;
}

public enum eTerritoryBorderRenderMode
{   //边界渲染模式
    None,     //只渲染主角边界
    Battle,             //渲染所有玩家边界
}