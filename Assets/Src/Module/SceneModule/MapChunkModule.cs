using System.Collections;
using System;
using System.Collections.Generic;
using MelandGame3;
using Cysharp.Threading.Tasks;
using Google.Protobuf.Collections;
using UnityEngine.Networking;
using UnityEngine;

/// <summary>
/// 地图chunk模块 这里面的所有Rect都是按照地图的坐标系俯视角来的 左下角为原点
/// </summary>
[DisallowMultipleComponent]
public class MapChunkModule : SceneModuleBase
{
    //安全区域对当前区域扩展范围 上下左右
    private static readonly (float, float, float, float) s_safeAreaExtendRange = (1, 1, 1, 1);
    //激活区域对安全区域扩展范围 上下左右
    private static readonly (float, float, float, float) s_activeAreaExtendRange = (SceneDefine.SCENE_VIEW_HEIGHT / 3, SceneDefine.SCENE_VIEW_HEIGHT / 3, SceneDefine.SCENE_VIEW_WIDTH / 3, SceneDefine.SCENE_VIEW_WIDTH / 3);

    //所有的服务器静态chunk数据 key为位置xy的ulong key
    private readonly Dictionary<ulong, MapChunk> _svrAllChunkRawDataMap = new();
    private readonly Dictionary<ulong, MapChunkLogic> _curActiveChunkLogicList = new();
    private Rect _curArea;//当前视野区域
    private Rect _safeArea;//安全区域 超过这个区域需要检查缓存新数据 在安全区域内怎么移动都不会有反应
    private Rect _curActiveDataArea;//当前激活缓存的数据区域 该区域覆盖的所有chunk数据都会激活


    private void Awake()
    {
        enabled = false;
    }

    public async void InitSvrChunkData(MapStaticData staticData)
    {
        if (string.IsNullOrEmpty(staticData.ChunkFile))
        {
            MLog.Error(eLogTag.map, "map static chunk ChunkFile not exist");
            Destroy(this);
            return;
        }

        MLog.Info(eLogTag.map, $"开始加载场景静态数据 file={staticData.ChunkFile}");

        byte[] chunkFile;
        try
        {
            string url = $"https://gateway-ipfs.melandworld.com/ipfs/{staticData.ChunkFile.Split("://")[1]}";
            UnityWebRequest result = await UnityWebRequest.Get(url).SendWebRequest();
            chunkFile = result.downloadHandler.data;
        }
        catch (Exception)
        {
            MLog.Error(eLogTag.map, "map static chunk ChunkFile download fail");
            Destroy(this);
            return;
        }

        if (chunkFile == null || chunkFile.Length <= 0)
        {
            MLog.Error(eLogTag.map, "map static chunk ChunkFile file is empty");
            Destroy(this);
            return;
        }

        _svrAllChunkRawDataMap.Clear();

        try
        {
            RepeatedField<MapChunk> chunks = MapChunkList.Parser.ParseFrom(chunkFile).Chunks;
            foreach (MapChunk chunk in chunks)
            {
                string[] fileInfo = chunk.Id.Split("_"); //"m71210544178151761_0_0_1614837944.map";
                int row = int.Parse(fileInfo[1]);
                int col = int.Parse(fileInfo[2]);
                (float x, float z) = NetUtil.RCToXZ(row, col);
                ulong key = MathUtil.TwoIntToUlong((int)x, (int)z);
                _svrAllChunkRawDataMap.Add(key, chunk);
            }
        }
        catch (Exception e)
        {
            MLog.Error(eLogTag.map, $"map static chunk ChunkFile parse fail ={e}");
            Destroy(this);
            return;
        }

        CheckMap();
        enabled = true;
    }

    private void Update()
    {
        CheckMap();
    }

    private void OnDrawGizmos()
    {
        if (!TestDefine.IS_SHOW_MAP_CHUNK)
        {
            return;
        }

        if (_safeArea == null)
        {
            return;
        }

        TestUtil.GizmosDrawSceneRect(_curArea, Color.red);
        TestUtil.GizmosDrawSceneRect(_safeArea, Color.green);
        TestUtil.GizmosDrawSceneRect(_curActiveDataArea, Color.blue);

        Gizmos.color = Color.red;
        foreach (MapChunkLogic chunkLogic in _curActiveChunkLogicList.Values)
        {
            (float x, float z) = NetUtil.RCToXZ(chunkLogic.RefSvrChunkData.OriginR, chunkLogic.RefSvrChunkData.OriginC);
            Gizmos.DrawSphere(new Vector3(x, 0, z), 1f);
        }
    }

    /// <summary>
    /// 检查地图
    /// </summary>
    private void CheckMap()
    {
        _curArea = GetCurCameraArea();
        if (_safeArea != null && _safeArea.Contains(_curArea))
        {
            return;
        }

        MLog.Info(eLogTag.map, $"地图块模块超过安全区 需要重新激活地图块");

        //重新计算范围
        _safeArea = CalculateExtendArea(_curArea, s_safeAreaExtendRange);
        _curActiveDataArea = CalculateExtendArea(_safeArea, s_activeAreaExtendRange);

        ActiveRangeChunk(_curActiveDataArea);
    }

    private static Rect GetCurCameraArea()
    {
        Rect area = new();
        Ray ray = new(Camera.main.transform.position, Camera.main.transform.forward);
        if (Mathf.Approximately(ray.direction.y, 0))
        {
            MLog.Error(eLogTag.map, "相机不能和水平面平行");
        }
        Vector3 point = MathUtil.GetPlaneInteractivePoint(ray, 0);
        area.size = new Vector2(SceneDefine.SCENE_VIEW_WIDTH, SceneDefine.SCENE_VIEW_HEIGHT);//现在按照相机最大范围来计算
        area.center = new Vector2(point.x, point.z);
        return area;
    }

    /// <summary>
    /// 激活范围内的chunk
    /// </summary>
    /// <param name="curActiveDataArea"></param>
    private void ActiveRangeChunk(Rect needActiveArea)
    {
        (HashSet<ulong> indexSet, ulong[] sortedIndex) = CalculateActiveChunkIndex(needActiveArea);

        //删除chunk
        List<ulong> needRemoveIndexList = new();
        foreach (KeyValuePair<ulong, MapChunkLogic> parent in _curActiveChunkLogicList)
        {
            if (!indexSet.Contains(parent.Key))
            {
                needRemoveIndexList.Add(parent.Key);
            }
        }
        foreach (ulong index in needRemoveIndexList)
        {
            try
            {
                MapChunkLogic logic = _curActiveChunkLogicList[index];
                _ = _curActiveChunkLogicList.Remove(index);
                logic.Dispose();
            }
            catch (Exception e)
            {
                MLog.Error(eLogTag.map, $"map chunk logic remove dispose fail ={e}");
                continue;
            }
        }

        //添加chunk
        foreach (ulong index in sortedIndex)
        {
            //没变化的
            if (_curActiveChunkLogicList.ContainsKey(index))
            {
                continue;
            }

            //新需要激活的chunk
            try
            {
                MapChunkLogic chunkLogic = new(index);
                _curActiveChunkLogicList.Add(index, chunkLogic);
                chunkLogic.Init(_svrAllChunkRawDataMap[index]);
            }
            catch (Exception e)
            {
                MLog.Error(eLogTag.map, $"map chunk logic add init fail ={e}");
                continue;
            }
        }
    }

    /// <summary>
    /// 计算激活chunk的所有index 有一定的排序性能损失
    /// </summary>
    /// <param name="indexSet"></param>
    /// <param name="needActiveArea"></param>
    /// <returns>indexSet用来查询 sortedIndex是以中心最近开始排序的</returns>
    private (HashSet<ulong> indexSet, ulong[] sortedIndex) CalculateActiveChunkIndex(Rect needActiveArea)
    {
        HashSet<ulong> indexSet = new();

        List<Vector3Int> chunkIndexList = new();
        if (GlobalDefine.IS_ADAPTIVE_OLD_DATA)
        {
            Vector3Int leftBottom = new()
            {
                x = (int)(needActiveArea.xMin / MapDefine.CHUNK_WIDTH) * MapDefine.CHUNK_WIDTH,
                y = 0,
                z = (int)(needActiveArea.yMin / MapDefine.CHUNK_HEIGHT) * MapDefine.CHUNK_HEIGHT
            };
            Vector3Int rightTop = new()
            {
                x = (int)(needActiveArea.xMax / MapDefine.CHUNK_WIDTH) * MapDefine.CHUNK_WIDTH,
                y = 0,
                z = (int)(needActiveArea.yMax / MapDefine.CHUNK_HEIGHT) * MapDefine.CHUNK_HEIGHT
            };
            for (int x = leftBottom.x; x <= rightTop.x; x += MapDefine.CHUNK_WIDTH)
            {
                for (int z = leftBottom.z; z <= rightTop.z; z += MapDefine.CHUNK_HEIGHT)
                {
                    chunkIndexList.Add(new Vector3Int(x, 0, z));
                    // ulong key = MathUtil.TwoIntToUlong(x, z);
                    // _ = indexSet.Add(key);
                }
            }

            Vector3Int sortCenter = (leftBottom + rightTop) / 2;

            chunkIndexList.Sort((a, b) =>
            {
                //不用距离计算 简单使用这种方式加快计算 计算周围格子的计算方式
                return Math.Abs(a.x - sortCenter.x) + Math.Abs(a.z - sortCenter.z)
                    - (Math.Abs(b.x - sortCenter.x) + Math.Abs(b.z - sortCenter.z));
            });
        }

        ulong[] sortedList = new ulong[chunkIndexList.Count];
        for (int i = 0; i < chunkIndexList.Count; i++)
        {
            Vector3Int index = chunkIndexList[i];
            ulong key = MathUtil.TwoIntToUlong(index.x, index.z);
            sortedList[i] = key;
            _ = indexSet.Add(key);
        }

        return (indexSet, sortedList);
    }

    /// <summary>
    /// 计算一个扩展的区域
    /// </summary>
    /// <param name="rect"></param>
    /// <param name="extendRange">上下左右</param>
    /// <returns></returns>
    private Rect CalculateExtendArea(Rect rect, (float, float, float, float) extendRange)
    {
        Rect extendRect = rect;
        extendRect.yMax += extendRange.Item1;
        extendRect.yMin -= extendRange.Item2;
        extendRect.xMin -= extendRange.Item3;
        extendRect.xMax += extendRange.Item4;
        return extendRect;
    }
}