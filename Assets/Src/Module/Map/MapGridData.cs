using UnityEngine;

/// <summary>
/// 地图格子数据 坐标为格子中心坐标
/// </summary>
public class MapGridData
{
    private readonly Vector3 _position;
    public MapGridData(int x, int z)
    {
        _position = new Vector3(x, 0, z);
    }

    public void Init()
    {

    }

    public void Dispose()
    {

    }
}