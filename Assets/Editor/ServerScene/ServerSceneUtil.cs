/*
 * @Author: xiang huan
 * @Date: 2022-07-12 15:17:07
 * @Description: 服务器场景工具
 * @FilePath: /meland-unity/Assets/Editor/ServerScene/ServerSceneUtil.cs
 * 
 */
using UnityEngine;

namespace Meland.Editor.ServerScene
{
    public sealed class ServerSceneUtil
    {
        public static void RetainCollisionComponent(GameObject gameObject)
        {
            //倒序删除 (避免RequireComponent的依赖导致无法删除)
            Component[] components = gameObject.GetComponents<Component>();
            for (int i = components.Length - 1; i >= 0; i--)
            {
                Component comp = components[i];
                if (!(comp is Transform) && !(comp is Collider))
                {
                    Object.DestroyImmediate(comp, true);
                }
            }

            int childCount = gameObject.transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Transform childTransform = gameObject.transform.GetChild(i);
                RetainCollisionComponent(childTransform.gameObject);
            }

        }
    }
}
