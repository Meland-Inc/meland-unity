/*
 * @Author: xiang huan
 * @Date: 2022-07-21 15:38:52
 * @Description: hud对象实例帮助
 * @FilePath: /meland-unity/Assets/Src/Framework/HUD/HUDHelper.cs
 * 
 */


using UnityEngine;
public class HUDHelper
{
    /// <summary>
    /// 实例化界面。
    /// </summary>
    /// <param name="uiAsset">要实例化的界面资源。</param>
    /// <returns>实例化后的界面。</returns>
    public object InstantiateUI(object uiAsset)
    {
        return Object.Instantiate((Object)uiAsset);
    }

    /// <summary>
    /// 创建界面。
    /// </summary>
    /// <param name="uiInstance">界面实例。</param>
    /// <param name="rootNode">根结点</param>
    /// <param name="userData">用户自定义数据。</param>
    /// <returns>界面。</returns>
    public HUDBase CreateUI(object uiInstance, GameObject rootNode, object userData)
    {
        GameObject gameObject = uiInstance as GameObject;
        if (gameObject == null)
        {
            MLog.Error(eLogTag.hud, "UI form instance is invalid.");
            return null;
        }

        Transform transform = gameObject.transform;
        transform.SetParent(rootNode.transform);
        transform.localScale = Vector3.one * GlobalDefine.PIX_TO_POS_UNIT;
        return gameObject.GetOrAddComponent<HUDBase>();
    }

    /// <summary>
    /// 释放界面。
    /// </summary>
    /// <param name="uiInstance">要释放的界面实例。</param>
    public void ReleaseUI(object uiInstance)
    {
        Object.Destroy((Object)uiInstance);
    }
}

