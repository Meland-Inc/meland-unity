
/*
 * @Author: xiang huan
 * @Date: 2022-07-20 15:33:50
 * @Description: 实体头部信息组件
 * @FilePath: /meland-unity/Assets/Src/Module/Entity/EntityHeadInfoCpt.cs
 * 
 */
using UnityEngine;

public class EntityHeadInfoCpt : HUDBaseCpt<HUDEntityHeadInfo>
{
    private void Awake()
    {
        CreateHUD(nameof(HUDEntityHeadInfo));
    }

    protected override void CreateHUDSuccess()
    {
        base.CreateHUDSuccess();
    }
    protected override void CreateHUDFailure()
    {
        base.CreateHUDFailure();
    }
}