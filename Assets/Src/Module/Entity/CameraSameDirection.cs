/// <summary>
/// 和相机相同朝向 主要添加了 看不到时不启用 节省性能
/// </summary>
public class CameraSameDirection : TargetSameDirection
{
    private void OnBecameVisible()
    {
        enabled = true;
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }
}