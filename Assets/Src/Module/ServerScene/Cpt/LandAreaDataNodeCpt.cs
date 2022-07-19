/*
 * @Author: xiang huan
 * @Date: 2022-06-27 14:13:48
 * @Description: 领地区域数据组件
 * @FilePath: /meland-unity/Assets/Src/Module/ServerScene/Cpt/LandAreaDataNodeCpt.cs
 * 
 */
using UnityEngine;
public class LandAreaDataNodeCpt : MonoBehaviour, IServerDataNodeCpt
{
    public object GetServerData()
    {
        LandAreaData data = new();
        data.MinX = (int)Mathf.Floor(transform.position.x - (transform.localScale.x / 2));
        data.MaxX = (int)Mathf.Floor(transform.position.x + (transform.localScale.x / 2));
        data.MinZ = (int)Mathf.Floor(transform.position.z - (transform.localScale.z / 2));
        data.MaxZ = (int)Mathf.Floor(transform.position.z + (transform.localScale.z / 2));
        return data;
    }
}