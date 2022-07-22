using UnityEngine;

public class MainRoleEntity : SceneEntity
{
    protected override void InitRoot()
    {
        //为了能和美术场景预览使用同一个预制件脚本配置 空物体主角的放在resource下当做配置同步加载上来
        GameObject prefab = Resources.Load<GameObject>(EntityDefine.MAIN_PLAYER_ROLE_SPECIAL_PREFAB_PATH);
        Root = Object.Instantiate(prefab);
    }

    protected override void InitToScene()
    {
        SetRootParent(SceneModule.SceneRender.Root);
    }

    protected override void UnInitFromScene()
    {
        SetRootParent(null);
    }
}