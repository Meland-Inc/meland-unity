/*
 * @Author: xiang huan
 * @Date: 2022-05-20 14:20:27
 * @LastEditTime 2022-06-21 21:16:40
 * @LastEditors Please set LastEditors
 * @Description: 资源工具类
 * @FilePath /Assets/Src/Util/AssetUtil.cs
 * 
 */

using System.IO;
using UnityEngine;

public static class AssetUtil
{
    public static string GetDataTableAssetPath(string assetName, bool fromBytes)
    {
        string path = fromBytes
            ? Path.Combine(AssetDefine.PATH_DATA_TABLE, "Bytes", $"{assetName}.bytes")
            : Path.Combine(AssetDefine.PATH_DATA_TABLE, "Csv", $"{assetName}.csv");
        return path;
    }

    public static string GetMusicPath(string assetName)
    {
        string path = Path.Combine(AssetDefine.PATH_MUSIC, $"{assetName}.mp3");
        return path;
    }
}