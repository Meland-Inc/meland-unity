/*
 * @Author: xiang huan
 * @Date: 2022-05-20 14:20:27
 * @LastEditTime: 2022-05-25 10:40:28
 * @LastEditors: xiang huan
 * @Description: 资源工具类
 * @FilePath: /meland-unity/Assets/Src/Util/AssetUtil.cs
 * 
 */

using System.IO;

public static class AssetUtil
{
    public static string GetDataTableAssetPath(string assetName, bool fromBytes)
    {
        string path = fromBytes
            ? Path.Combine(Resource.PATH_DATA_TABLE, "Bytes", $"{assetName}.bytes")
            : Path.Combine(Resource.PATH_DATA_TABLE, "Csv", $"{assetName}.csv");
        return path;
    }
}