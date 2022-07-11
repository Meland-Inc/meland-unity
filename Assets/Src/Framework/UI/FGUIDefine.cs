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
    public const string EQUIPMENT_SLOT_RES = "EquipmentSlot";
}