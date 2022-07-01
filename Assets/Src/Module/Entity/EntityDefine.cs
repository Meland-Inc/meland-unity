public class EntityDefine
{
    /// <summary>
    /// 为了能和美术场景预览使用同一个预制件脚本配置 主角的放在resouce下当做配置同步加载上来
    /// </summary>
    public const string MAIN_PLAYER_ROLE_SPECIAL_PREFAB_PATH = "prefab/MainPlayerRole";
    /// <summary>
    /// 默认玩家移动速度
    /// </summary>
    public const float DEFINE_PLAYER_MOVE_SPEED = 3f;
    /// <summary>
    /// 纸片物件的共用预制体
    /// </summary>
    public const string PAPER_ELEMENT_PREFAB_ASSET = "PaperElement.prefab";
    /// <summary>
    /// 水平纸片元素共用的预制体
    /// </summary>
    public const string HORIZONTAL_ELEMENT_PREFAB_ASSET = "HorizontalElement.prefab";
    /// <summary>
    /// 地表块共用预制件
    /// </summary>
    public const string TERRAIN_UNIT_PREFAB_ASSET = "TerrainUnitModel.prefab";
    /// <summary>
    /// 玩家角色预制件
    /// </summary>
    public const string PLAYER_ROLE_PREFAB_ASSET = "PlayerRole.prefab";

    /// <summary>
    /// GF entity 的分组 物件组
    /// </summary>
    public const string GF_ENTITY_GROUP_ELEMENT = "element";
    /// <summary>
    /// GF entity 的分组 地表
    /// </summary>
    public const string GF_ENTITY_GROUP_TERRAIN = "terrain";
    /// <summary>
    /// GF entity 的分组 角色
    /// </summary>
    public const string GF_ENTITY_GROUP_ROLE = "role";

    /// <summary>
    /// avatar2d 基础皮肤名
    /// </summary>
    public const string AVATAR_BASE_SKIN = "skin-base";

    /// <summary>
    /// 通用动画名 idle
    /// </summary>
    public const string ANIM_NAME_IDLE = "idle";
    /// <summary>
    /// 通用动画名 run
    /// </summary>
    public const string ANIM_NAME_RUN = "walk";
}