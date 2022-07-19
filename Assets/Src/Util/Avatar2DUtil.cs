using System.IO;
using System.Collections.Generic;
/// <summary>
/// 一些控制avatar2d的工具 主要是spine动画的
/// </summary>
public static class Avatar2DUtil
{
    /// <summary>
    /// 获取主骨架资源完整路径
    /// </summary>
    /// <param name="roleCfgID"></param>
    /// <returns></returns>
    public static string GetRoleSkeletonRes(int roleCfgID)
    {
        DRRole drRole = GFEntry.DataTable.GetDataTable<DRRole>().GetDataRow(roleCfgID);
        if (drRole == null)
        {
            MLog.Error(eLogTag.avatar, $"not find role cfgID={roleCfgID}");
            return "";
        }

        DRRoleAsset drRoleAsset = GFEntry.DataTable.GetDataTable<DRRoleAsset>().GetDataRow(drRole.RoleAssetID);
        if (drRoleAsset == null)
        {
            MLog.Error(eLogTag.avatar, $"not find role asset cfgID={drRole.RoleAssetID}");
            return "";
        }

        return Path.Combine(AssetDefine.PATH_SPINE_DATA_ROLE, drRoleAsset.ArmatureRes + AssetDefine.SUFFIX_ASSET);
    }

    /// <summary>
    /// 获取部件资源完整路径列表
    /// </summary>
    /// <param name="roleCfgID">角色配置ID 部件ID下不同角色资源名不一样</param>
    /// <param name="partIds">部件ID</param>
    /// <returns></returns>
    public static List<string> GetPartResList(int roleCfgID, IEnumerable<int> partIds)
    {
        List<string> partList = new();
        foreach (int partId in partIds)
        {
            DRAvatar drAvatar = GFEntry.DataTable.GetDataTable<DRAvatar>().GetDataRow(partId);
            if (drAvatar == null)
            {
                continue;
            }

            //TODO:按照之前逻辑是要判断角色ID去拿具体的资源 现在临时测试 先不用
            partList.Add(drAvatar.ResouceBoy);
        }

        return partList;
    }
}