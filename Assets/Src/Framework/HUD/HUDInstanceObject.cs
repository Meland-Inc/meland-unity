/*
 * @Author: xiang huan
 * @Date: 2022-07-21 14:58:00
 * @Description: hud对象池实例
 * @FilePath: /meland-unity/Assets/Src/Framework/HUD/HUDInstanceObject.cs
 * 
 */

using GameFramework;
using GameFramework.ObjectPool;

public class HUDInstanceObject : ObjectBase
{
    private HUDHelper _hudHelper;

    public HUDInstanceObject()
    {
        _hudHelper = null;
    }

    public static HUDInstanceObject Create(string name, object hudInstance, HUDHelper hudHelper)
    {
        if (hudInstance == null)
        {
            MLog.Error(eLogTag.hud, "HUD  hudInstance is invalid.");
        }

        HUDInstanceObject hudInstanceObject = ReferencePool.Acquire<HUDInstanceObject>();
        hudInstanceObject.Initialize(name, hudInstance);
        hudInstanceObject._hudHelper = hudHelper;
        return hudInstanceObject;
    }

    public override void Clear()
    {
        base.Clear();
        _hudHelper = null;
    }

    protected override void Release(bool isShutdown)
    {
        _hudHelper.ReleaseUI(Target);
    }
}
