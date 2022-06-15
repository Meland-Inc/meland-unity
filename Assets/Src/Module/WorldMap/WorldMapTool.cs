using System.Text;
using System;
using System.Collections.Generic;
using FairyGUI;
using UnityEngine;
namespace WorldMap
{
    public class WorldMapTool
    {
        public const string URL_INFO_SPLIT_FLAG = "##";
        public const int MAP_GIRD_WIDTH = 2048;
        public const int MAP_GIRD_HEIGHT = 2048;
        public int MapWidthCache { get; private set; }
        public int MapHeightCache { get; private set; }
        public float MapRatioCache { get; private set; }
        public Dictionary<int, MLoader> MapPartDic { get; } = new();

        /// <summary>
        /// 通过ipfs地址获取地图以及信息
        /// </summary>
        /// <param name="urls">url数组，一整张大地图有多个小的地图拼成</param>
        public GComponent LoadMapFromIpfsUrls(string[] urls)
        {
            GComponent com = new();
            foreach (string url in urls)
            {
                _ = AddMapPart(url, com);
            }

            com.width = MapWidthCache;
            com.height = MapHeightCache;
            return com;
        }

        /// <summary>
        /// 组装地图
        /// </summary>
        /// <param name="url"></param>
        /// <returns>true|false,解析url是否成功</returns>
        private MLoader AddMapPart(string url, GComponent container)
        {
            int flagIndex = url.IndexOf(URL_INFO_SPLIT_FLAG);
            if (flagIndex == -1)
            {
                MLog.Error(eLogTag.worldMap, "url error: " + url);
                return null;
            }
            string[] urlSplit = url.Split(URL_INFO_SPLIT_FLAG);
            if (urlSplit.Length != 2)
            {
                MLog.Error(eLogTag.worldMap, "url error: " + url);
                return null;
            }
            string urlInfoStr = urlSplit[1];
            IpfsUrlMapInfo mapInfo = JsonUtility.FromJson<IpfsUrlMapInfo>(urlInfoStr);
            if (mapInfo == null)
            {
                MLog.Error(eLogTag.worldMap, "mapInfo is null: " + url);
                return null;
            }

            MapWidthCache = mapInfo.w > 0 ? mapInfo.w : MapWidthCache;
            MapHeightCache = mapInfo.h > 0 ? mapInfo.h : MapHeightCache;
            MapRatioCache = mapInfo.ratio > 0 ? mapInfo.ratio : MapRatioCache;


            MLoader loader = new()
            {
                url = urlSplit[0],
                autoSize = true,
                align = AlignType.Center,
                verticalAlign = VertAlignType.Middle,
                x = mapInfo.col * MAP_GIRD_WIDTH,
                y = mapInfo.row * MAP_GIRD_HEIGHT,
                name = $"{mapInfo.col}_{mapInfo.row}",
            };

            _ = container.AddChild(loader);
            return loader;
        }

        public static int RC2MapPartKey(int row, int col)
        {
            return (row << 10) | col;//2**10=1024,够用了
        }

        public static (int, int) MapPartKey2RC(int key)
        {
            return (key >> 10, key & 0x3ff);//0x3ff == 1023 == 0b11111111111111
        }

        public static (int, int) RCIndex2RC(int index)
        {
            int row = index / 1000;//todo:1000应该要获取地图数据的
            int col = index % 1000;
            return (row, col);
        }

        public static int RC2RCIndex(int row, int col)
        {
            return (row * 1000) + col;
        }
    }
}