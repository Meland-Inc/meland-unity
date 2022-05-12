/// <summary>
/// 看向目标
/// </summary>
public class LookTarget : TransformTarget
{
    private void LateUpdate()
    {
        if (!TargetTsm)
        {
            return;
        }

        transform.LookAt(TargetTsm);
    }
}