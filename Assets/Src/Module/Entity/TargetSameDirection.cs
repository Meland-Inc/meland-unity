/// <summary>
/// 和目标朝向一致 如果camera无法看到时节省性能的话请使用 CameraSameDirection
/// </summary>
public class TargetSameDirection : TransformTarget
{
    private void LateUpdate()
    {
        if (!TargetTsm)
        {
            return;
        }

        transform.forward = TargetTsm.forward;
    }
}