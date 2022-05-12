using UnityEngine;

/// <summary>
/// 和相机朝向保持一致
/// </summary>
public class SameCameraDirection : TargetSameDirection
{
    protected override void Start()
    {
        base.Start();

        if (Camera.main)
        {
            SetTargetTsm(Camera.main.transform);
        }
    }
}