/*
 * @Author: xiang huan
 * @Date: 2022-06-27 14:13:48
 * @Description: 数据节点list组件
 * @FilePath: /meland-unity/Assets/Src/Module/ServerScene/Cpt/ServerDataNodeListCpt.cs
 * 
 */
using System.Collections.Generic;
using UnityEngine;
public class ServerDataNodeListCpt : MonoBehaviour, IServerDataNodeCpt
{
    public object GetServerData()
    {
        List<object> list = new();
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform childTransform = transform.GetChild(i);
            if (childTransform.gameObject.TryGetComponent(out IServerDataNodeCpt dataCpt))
            {
                list.Add(dataCpt.GetServerData());
            }
        }
        return list;
    }
}