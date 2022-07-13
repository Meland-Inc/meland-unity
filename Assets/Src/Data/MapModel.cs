using Bian;
using UnityEngine;

/// <summary>
/// 地图数据 和场景不一样的是 这个往往是和服务器数据有关 具体的某个地图数据
/// </summary>
public class MapModel : DataModelBase
{
    [SerializeField]
    private Rect _range;
    /// <summary>
    /// 地图的范围 Rect原点在左下角 和场景一致
    /// </summary>
    public Rect Range => _range;

    [SerializeField]
    private int _mapId;
    public int MapID => _mapId;
    [SerializeField]
    private int _mapRowTileNum;
    public int MapRowTileNum => _mapRowTileNum;
    [SerializeField]
    private int _mapColTileNum;
    public int MapColTileNum => _mapColTileNum;
    [SerializeField]
    private int _mapOffsetRowTileNum;
    public int MapOffsetRowTileNum => _mapOffsetRowTileNum;
    [SerializeField]
    private int _mapOffsetCowTileNum;
    public int MapOffsetCowTileNum => _mapOffsetCowTileNum;

    /// <summary>
    /// 初始化服务器数据
    /// </summary>
    /// <param name="svrMapData"></param>
    public void InitSvrData(Map svrMapData)
    {
        InitMapRangeSize((int)svrMapData.MapWidth, (int)svrMapData.MapHeight);

        _mapId = svrMapData.Id;
        _mapRowTileNum = svrMapData.RhombR;
        _mapColTileNum = svrMapData.RhombC;
        _mapOffsetRowTileNum = svrMapData.RhombOffsetR;
        _mapOffsetCowTileNum = svrMapData.RhombOffsetC;
    }

    private void InitMapRangeSize(int width, int height)
    {
        Rect range = new()
        {
            width = width,
            height = height,
            xMin = 0
        };
        if (GlobalDefine.IS_ADAPTIVE_OLD_DATA)
        {
            range.yMin = NetUtil.SvrScreenYToClient(range.height);
        }
        else
        {
            range.yMin = 0;
        }
        _range = range;
    }
}