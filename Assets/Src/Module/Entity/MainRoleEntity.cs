using UnityEngine;

public class MainRoleEntity : SceneEntity
{
    public MainRoleEntity() : base()
    {
        AddComponent<MoveNetRequest>().enabled = false;
    }
    protected override void InitRoot()
    {
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