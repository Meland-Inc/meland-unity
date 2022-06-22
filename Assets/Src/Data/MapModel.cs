using System.Collections.Generic;
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
    /// 格子数据map key为x和z的拼接
    /// </summary>
    /// <returns></returns>
    private Dictionary<ulong, MapGridData> _gridDataMap = new();

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

        if (svrMapData.StaticData != null && svrMapData.StaticData.Using)
        {
            MapChunkModule chunkModule = SceneModule.Root.AddComponent<MapChunkModule>();
            chunkModule.InitSvrChunkData(svrMapData.StaticData);
        }
        else
        {
            MLog.Error(eLogTag.map, "map static chunk is null or not using");
        }
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

    public void AddGridData(int x, int z)
    {
        ulong key = MathUtil.TwoIntToUlong(x, z);
        if (_gridDataMap.ContainsKey(key))
        {
            MLog.Error(eLogTag.map, $"add grid data repeated! =[{x},{z}]");
            return;
        }

        MapGridData gridData = new(x, z);
        gridData.Init();
        _gridDataMap.Add(key, gridData);
    }

    public void RemoveGridData(int x, int z)
    {
        ulong key = MathUtil.TwoIntToUlong(x, z);
        if (_gridDataMap.TryGetValue(key, out MapGridData gridData))
        {
            _ = _gridDataMap.Remove(key);
            gridData.Dispose();
        }
        else
        {
            MLog.Error(eLogTag.map, $"remove grid data,key not exist =[{x},{z}]");

        }
    }

    /// <summary>
    /// 获取当前坐标的格子数据 找不到返回null 只用于水平面上的格子划分
    /// </summary>
    /// <param name="x"></param>
    /// <param name="z"></param>
    /// <returns></returns>
    public MapGridData GetGridData(float x, float z)
    {
        ulong key = MathUtil.TwoIntToUlong(Mathf.RoundToInt(x), Mathf.RoundToInt(z));
        return _gridDataMap.TryGetValue(key, out MapGridData gridData) ? gridData : null;
    }
}