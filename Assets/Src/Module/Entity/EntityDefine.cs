/// <summary>
/// 实体类型
/// </summary>
public enum eEntityType : uint
{
    unkown = 0,
    player = 1 << 0,
    monster = 1 << 1,
    sceneElement = 1 << 2,
}