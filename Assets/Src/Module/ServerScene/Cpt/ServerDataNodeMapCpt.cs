/*
 * @Author: xiang huan
 * @Date: 2022-06-27 14:13:48
 * @Description: 数据节点map组件
 * @FilePath: /meland-unity/Assets/Src/Module/ServerScene/Cpt/ServerDataNodeMapCpt.cs
 * 
 */
using System.Collections.Generic;
using UnityEngine;
public class ServerDataNodeMapCpt : MonoBehaviour, IServerDataNodeCpt
{
    public object GetServerData()
    {
        Dictionary<string, object> map = new();
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform childTransform = transform.GetChild(i);
            GameObject gameObject = childTransform.gameObject;
            if (gameObject.TryGetComponent(out IServerDataNodeCpt dataCpt))
            {
                if (map.ContainsKey(gameObject.name))
                {
                    map[gameObject.name] = dataCpt.GetServerData();
                }
                else
                {
                    map.Add(gameObject.name, dataCpt.GetServerData());
                }
            }
        }
        return map;
    }
}