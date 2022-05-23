using Bian;
using UnityEngine;

/// <summary>
/// 地图数据 和场景不一样的是 这个往往是和服务器数据有关 具体的某个地图数据
/// </summary>
public class MapModel : DataModelBase
{
    [SerializeField]
    private Rect _range;
    public Rect Range => _range;

    [SerializeField]
    private int _mapId;
    public int MapID => _mapId;

    /// <summary>
    /// 初始化服务器数据
    /// </summary>
    /// <param name="svrMapData"></param>
    public void InitSvrData(Map svrMapData)
    {
        InitMapRangeSize(svrMapData.MapWidth, svrMapData.MapHeight);

        _mapId = svrMapData.Id;

        MapChunkModule chunkModule = SceneModule.Root.AddComponent<MapChunkModule>();
        chunkModule.InitSvrChunkData(svrMapData);
    }

    private void InitMapRangeSize(float width, float height)
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