public enum eUIGroup
{
    Form,
    Tooltip,
    Toast,
    Dialog,
    Alert,
    Log
}

public enum eTooltipDir
{
    Top,
    Bottom,
    Left,
    Right,
    Auto,
}

public enum eFUIPackage
{
    Common,
    Login,
    Main,
    CreateRole,
    Backpack,
    Player,
    Task,
}

public static class UIDefine
{
    public const int MAX_FORM_NUM_IN_GROUP = 1000;
}

public static class FGUIDefine
{
    public const string EMPTY_ITEM_RES = "emptyItem";
    public const string NFT_ITEM_RES = "BpNftItemRenderer";
    public const string NFT_EQUIP_ITEM_RES = "EquipNftItemRenderer";
    public const string NFT_REWARD_ITEM_RES = "RewardNftItemRenderer";
    public const string EQUIPMENT_SLOT_RES = "EquipmentSlot";
    public const string UI_AVATAR_RES = "ComUIAvatar";
    public const string TASK_MENU_ITEM_RES = "TaskMenuItemRender";
    public const string TASK_TRACKER_ITEM_RES = "ComTaskTrackerItem";
    public const string COM_LABEL_CUR_MAX_RES = "comLabelCurMax";
}