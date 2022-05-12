/// <summary>
/// 和目标朝向一致
/// </summary>
public class TargetSameDirection : TransformTarget
{
    void LateUpdate()
    {
        if (!TargetTsm)
        {
            return;
        }

        transform.forward = TargetTsm.forward;
    }
}