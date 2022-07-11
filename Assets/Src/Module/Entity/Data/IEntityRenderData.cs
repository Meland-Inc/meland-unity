/// <summary>
/// 实体渲染数据
/// </summary>
public interface IEntityRenderData
{
    /// <summary>
    /// 资源类型 说明是3d还是2d等 和配置表中一样
    /// </summary>
    /// <value></value>
    int AssetType { get; }
    /// <summary>
    /// 完整路径 已经是把配置表中的拼装好了 包括了后缀
    /// </summary>
    /// <value></value>
    string AssetFullPath { get; }
    /// <summary>
    /// 配置表中的原始路径
    /// </summary>
    /// <value></value>
    string AssetConfigPath { get; }
    /// <summary>
    /// 2d纸片是否水平放置 比如地板
    /// </summary>
    /// <value></value>
    bool IsHorizontal { get; }
    /// <summary>
    /// 是否看向相机 和相机的方向一致
    /// </summary>
    /// <value></value>
    bool IsLookCamera { get; }
}