using System.IO;
namespace WorldMap
{
    // public class WorldDefine
    // {
    //     public const string WorldMap_MapDisplay = "WorldMap/MapDisplay";
    //     public const string WorldMap_MapPosTipsLogic = "WorldMap/MapPosTipsLogic";
    //     public const string WorldMap_VipLandLogoLogic = "WorldMap/VipLandLogoLogic";
    // }

    [System.Serializable]
    public class IpfsUrlMapInfo
    {
        public int row;
        public int col;
        public int w;
        public int h;
        public float ratio;
    }

    public static class WorldMapDefine
    {
        public static readonly string[] s_WorldMapUrls = new[]
        {
            Path.Combine(AssetDefine.PATH_WORLD_MAP, "world_map_grid_0.jpg##{\"row\":0,\"col\":0,\"w\":6001,\"h\":6088,\"ratio\":0.1}"),
            Path.Combine(AssetDefine.PATH_WORLD_MAP, "world_map_grid_1.jpg##{\"row\":0,\"col\":1}"),
            Path.Combine(AssetDefine.PATH_WORLD_MAP, "world_map_grid_2.jpg##{\"row\":0,\"col\":2}"),
            Path.Combine(AssetDefine.PATH_WORLD_MAP, "world_map_grid_3.jpg##{\"row\":1,\"col\":0}"),
            Path.Combine(AssetDefine.PATH_WORLD_MAP, "world_map_grid_4.jpg##{\"row\":1,\"col\":1}"),
            Path.Combine(AssetDefine.PATH_WORLD_MAP, "world_map_grid_5.jpg##{\"row\":1,\"col\":2}"),
            Path.Combine(AssetDefine.PATH_WORLD_MAP, "world_map_grid_6.jpg##{\"row\":2,\"col\":0}"),
            Path.Combine(AssetDefine.PATH_WORLD_MAP, "world_map_grid_7.jpg##{\"row\":2,\"col\":1}"),
            Path.Combine(AssetDefine.PATH_WORLD_MAP, "world_map_grid_8.jpg##{\"row\":2,\"col\":2}")
        };

        public const float MAP_RATIO = 0.3f;
        public const float MAX_MAP_SCALE = 2f;
        public const float MIN_MAP_SCALE = 0.3f;
        public const float SCALE_SPEED = 0.02f;
    }
}