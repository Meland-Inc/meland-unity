using System.Collections.Generic;
using System;
using System.IO;
using Bian;
using UnityGameFramework.Runtime;

/// <summary>
/// 地图chunk逻辑 包含了创建静态地图物件和销毁管理的数据能力
/// </summary>
public class MapChunkLogic
{
    public ulong Key { get; }
    private readonly int _cacheMapWidth;//地图宽 缓存加速性能
    private HashSet<int> _curShowTerrainIDs = new();// 当前显示的地表块ID
    public MapChunkLogic(ulong key)
    {
        Key = key;
        _cacheMapWidth = (int)MathF.Round(DataManager.GetModel<MapModel>().Range.width);
    }

    public void Init(MapChunk svrChunk)
    {
        EntityComponent entityMgr = GFEntry.Entity;
        foreach (BlockSettings block in svrChunk.Blocks)
        {
            try
            {
                if (block == null)
                {
                    continue;
                }

                if (block.Objs == null || block.Objs.Count == 0)
                {
                    continue;
                }

                (float x, float z) = NetUtil.RCToXZ(block.R, block.C);

                foreach (BlockObj obj in block.Objs)
                {

                    DREntity dr = GFEntry.DataTable.GetDataTable<DREntity>().GetDataRow(obj.ObjId);
                    if (dr == null)
                    {
                        MLog.Error(eLogTag.entity, $"MapChunkLogic not find entity dr error =[{obj.ObjId}],pos=[{block.R},{block.C}]");
                        continue;
                    }

                    if (!dr.IsTerrain)
                    {
                        continue;
                    }

                    if (dr.RectTexture == null || dr.RectTexture.Length == 0)
                    {
                        MLog.Error(eLogTag.entity, $"MapChunkLogic not find rect texture =[{obj.ObjId}],pos=[{block.R},{block.C}]");
                        continue;
                    }

                    RenderOneTerrain(entityMgr, dr.RectTexture[0], x, z);
                    break;
                };
            }
            catch (Exception e)
            {
                MLog.Error(eLogTag.map, $"MapChunkLogic add terrain error ={e}");
                continue;
            }
        }
    }

    public void Dispose()
    {
        EntityComponent entityMgr = GFEntry.Entity;
        foreach (int terrainID in _curShowTerrainIDs)
        {
            entityMgr.HideEntity(terrainID);
        }
    }

    private void RenderOneTerrain(EntityComponent entityMgr, string textureAsset, float x, float z)
    {
        string prefabAsset = Path.Combine(ResourceDefine.PATH_MAP_ELEMENT, EntityDefine.TERRAIN_UNIT_PREFAB_ASSET);
        TerrainRenderTempData data = new()
        {
            Position = new UnityEngine.Vector3(x, 0f, z),
            TextureAsset = textureAsset
        };
        int entityID = GetTerrainEntityID((int)x, (int)z);
        entityMgr.ShowEntity<TerrainRender>(entityID, prefabAsset, EntityDefine.GF_ENTITY_GROUP_TERRAIN, (int)eLoadPriority.Terrain, data);
        bool res = _curShowTerrainIDs.Add(entityID);
        if (!res)
        {
            MLog.Error(eLogTag.map, $"MapChunkLogic entity id repeated ={entityID}");
        }
    }

    private int GetTerrainEntityID(int x, int z)
    {
        return x + (z * _cacheMapWidth);
    }
}