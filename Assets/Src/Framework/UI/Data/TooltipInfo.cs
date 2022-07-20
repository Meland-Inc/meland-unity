/*
 * @Author: mangit
 * @LastEditors: wym
 * @Description: tooltip 信息
 * @Date: 2022-06-22 14:40:08
 * @FilePath: /Assets/Src/Framework/UI/Data/TooltipInfo.cs
 */
using FairyGUI;
public class TooltipInfo
{
    public GObject Reference { get; private set; }
    public object Data { get; private set; }
    public eTooltipDir Dir { get; private set; }
    public int OffsetX { get; private set; }
    public int OffsetY { get; private set; }
    public bool IsTouchRootClose { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="reference">tooltip位置参照物</param>
    /// <param name="data">tooltip 自定义数据，业务处按需强转</param>
    /// <param name="dir">默认是Auto，tooltip相对参照物方向</param>
    /// <param name="offsetX">tooltip x偏移值</param>
    /// <param name="offsetY">tooltip y偏移值</param>
    /// <param name="isTouchRootClose">点击到根 自动关闭Tooltip</param>
    public TooltipInfo(GObject reference, object data, eTooltipDir dir = eTooltipDir.Auto, int offsetX = 0, int offsetY = 0, bool isTouchRootClose = true)
    {
        Reference = reference;
        Data = data;
        Dir = dir;
        OffsetX = offsetX;
        OffsetY = offsetY;
        IsTouchRootClose = isTouchRootClose;
    }
}