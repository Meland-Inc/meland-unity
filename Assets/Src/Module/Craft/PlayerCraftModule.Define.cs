using System.Diagnostics.Contracts;
public partial class PlayerCraftModule
{
    /// <summary>
    /// 合成类型
    /// </summary>
    public enum eCraftType
    {
        weapon = 1001,
        defense,
        cure,
    }

    /// <summary>
    /// 配方展示类型，对于Recipes配置表中的displayType字段，
    /// </summary>
    public enum eRecipeDisplayType
    {
        Skill = 1,
        Craft
    }
}