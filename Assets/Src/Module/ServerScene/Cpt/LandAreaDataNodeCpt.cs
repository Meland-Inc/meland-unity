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
        data.MinR = (int)Mathf.Floor(transform.position.z - (transform.localScale.z / 2));
        data.MaxR = (int)Mathf.Floor(transform.position.z + (transform.localScale.z / 2));
        data.MinC = (int)Mathf.Floor(transform.position.x - (transform.localScale.x / 2));
        data.MaxC = (int)Mathf.Floor(transform.position.x + (transform.localScale.x / 2));
        return data;
    }
}