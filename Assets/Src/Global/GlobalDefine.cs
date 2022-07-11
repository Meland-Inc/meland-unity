/// <summary>
/// 全局定义
/// </summary>
public static class GlobalDefine
{
    /// <summary>
    /// 适配老数据
    /// </summary>
    public static readonly bool IS_ADAPTIVE_OLD_DATA = true;

    /// <summary>
    /// 坐标单位转换成像素
    /// </summary>
    public static readonly float POS_UNIT_TO_PIX = 100;
    /// <summary>
    /// 像素转换成坐标单位
    /// </summary>
    public static readonly float PIX_TO_POS_UNIT = 1 / POS_UNIT_TO_PIX;
}

/**八方向  不要乱改值  改了需要将菱形和矩形ALL更新 */
public enum eDirection
{
    NONE = 0,
    LEFT_UP = 1,
    LEFT_DOWN = 2,
    RIGHT_DOWN = 4,
    RIGHT_UP = 8,
    UP = 16,
    LEFT = 32,
    DOWN = 64,
    RIGHT = 128,
    MAX = 256,//1 0000 0000
    /**所有方向 */
    ALL = MAX - 1,//1111 1111
    /**菱形的四边方向 */
    RHOMB_ALL = UP - 1,//0000 1111
    /**矩形的四边方向 */
    RECT_ALL = ALL & ~RHOMB_ALL,//1111 0000
}