using UnityEngine;


/// <summary>
/// 美术用来预览场景的脚本 只会存在预览场景logic场景中 不会在正式代码中执行
/// </summary>
public class ScenePreview : MonoBehaviour
{
    public Transform MainRole;
    public TargetSameDirection MainRoleSameDirection;
    private void Start()
    {
        if (Camera.main != null)
        {
            SetMainCamera();
        }
        else
        {
            Debug.LogError("没有主相机，相机无法跟随");
        }
    }

    private void SetMainCamera()
    {
        if (Camera.main.TryGetComponent<FollowTarget>(out FollowTarget cameraFollowTarget))
        {
            cameraFollowTarget.SetTargetTsm(MainRole);

        }

        TargetSameDirection sameDirection = GetComponentInChildren<TargetSameDirection>();
        MainRoleSameDirection?.SetTargetTsm(Camera.main.transform);
    }
}