using System;
using System.Collections.Generic;
using Bian;
using Cysharp.Threading.Tasks;
using Google.Protobuf.Collections;
using UnityEngine.Networking;
using UnityEngine;

/// <summary>
/// 地图chunk模块 这里面的所有Rect都是按照地图的坐标系俯视角来的 左下角为原点
/// </summary>
public class MapChunkModule : SceneModuleBase
{
    //安全区域对当前区域扩展范围 上下左右
    private static readonly (float, float, float, float) s_safeAreaExtendRange = (SceneDefine.SCENE_VIEW_HEIGHT / 2, SceneDefine.SCENE_VIEW_HEIGHT / 2, SceneDefine.SCENE_VIEW_WIDTH / 2, SceneDefine.SCENE_VIEW_WIDTH / 2);
    //激活区域对安全区域扩展范围 上下左右
    private static readonly (float, float, float, float) s_activeAreaExtendRange = (SceneDefine.SCENE_VIEW_HEIGHT / 2, SceneDefine.SCENE_VIEW_HEIGHT / 2, SceneDefine.SCENE_VIEW_WIDTH / 2, SceneDefine.SCENE_VIEW_WIDTH / 2);

    //所有的服务器静态chunk数据 key为位置xy的ulong key
    private readonly Dictionary<ulong, MapChunk> _svrAllChunkRawDataMap = new();
    private readonly Dictionary<ulong, MapChunkLogic> _curActiveChunkLogicList = new();
    private Rect _safeArea;//安全区域 超过这个区域需要检查缓存新数据
    private Rect _curActiveDataArea;//当前激活缓存的数据区域


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
            UnityWebRequest result = await UnityWebRequest.Get(staticData.ChunkFile).SendWebRequest();
            chunkFile = result.downloadHandler.data;
        }
        catch (Exception)
        {
            MLog.Fatal(eLogTag.map, "map static chunk ChunkFile download fail");
            Destroy(this);
            return;
        }

        if (chunkFile == null || chunkFile.Length <= 0)
        {
            MLog.Fatal(eLogTag.map, "map static chunk ChunkFile file is empty");
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
            MLog.Fatal(eLogTag.map, $"map static chunk ChunkFile parse fail ={e}");
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

    /// <summary>
    /// 检查地图
    /// </summary>
    private void CheckMap()
    {
        Rect curArea = GetCurCameraArea();
        if (_safeArea != null && _safeArea.Contains(curArea))
        {
            return;
        }

        MLog.Info(eLogTag.map, $"地图块模块超过安全区 需要重新激活地图块");

        //重新计算范围
        _safeArea = CalculateExtendArea(curArea, s_safeAreaExtendRange);
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
        area.center = new Vector2(point.x, point.z);
        area.size = new Vector2(SceneDefine.SCENE_VIEW_WIDTH, SceneDefine.SCENE_VIEW_HEIGHT);//现在按照相机最大范围来计算
        return area;
    }

    /// <summary>
    /// 激活范围内的chunk
    /// </summary>
    /// <param name="curActiveDataArea"></param>
    private void ActiveRangeChunk(Rect needActiveArea)
    {
        HashSet<ulong> allActiveChunkIndex = CalculateActiveChunkIndex(needActiveArea);

        //删除chunk
        List<ulong> needRemoveIndexList = new();
        foreach (KeyValuePair<ulong, MapChunkLogic> parent in _curActiveChunkLogicList)
        {
            if (!allActiveChunkIndex.Contains(parent.Key))
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
        foreach (ulong index in allActiveChunkIndex)
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
    /// 计算激活chunk的所有index
    /// </summary>
    /// <param name="needActiveArea"></param>
    /// <returns></returns>
    private HashSet<ulong> CalculateActiveChunkIndex(Rect needActiveArea)
    {
        HashSet<ulong> activeChunkIndex = new();

        if (GlobalDefine.IS_ADAPTIVE_OLD_DATA)
        {
            int leftBottomChunkX = (int)(needActiveArea.xMin / MapDefine.CHUNK_WIDTH) * MapDefine.CHUNK_WIDTH;//算出左下角的chunk坐标（chunk坐标为chunk的左上角）
            int leftBottomChunkY = (int)(needActiveArea.yMin / MapDefine.CHUNK_HEIGHT) * MapDefine.CHUNK_HEIGHT;
            for (int x = 0; x <= leftBottomChunkX + needActiveArea.width; x += MapDefine.CHUNK_WIDTH)
            {
                for (int y = 0; y <= leftBottomChunkY + needActiveArea.height; y += MapDefine.CHUNK_HEIGHT)
                {
                    ulong key = MathUtil.TwoIntToUlong(x, y);
                    _ = activeChunkIndex.Add(key);
                }
            }
        }

        return activeChunkIndex;
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
        rect.yMax += extendRange.Item1;
        rect.yMin -= extendRange.Item2;
        rect.xMin -= extendRange.Item3;
        rect.xMax += extendRange.Item4;
        return extendRect;
    }
}