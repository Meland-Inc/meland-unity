/*
 * @Author: xiang huan
 * @Date: 2022-06-27 14:13:48
 * @Description: 资源点数据组件
 * @FilePath: /meland-unity/Assets/Src/Module/ServerScene/Cpt/ResourcesPointDataNodeCpt.cs
 * 
 */
using UnityEngine;
public class ResourcesPointDataNodeCpt : MonoBehaviour, IServerDataNodeCpt
{
    [Tooltip("资源类型1. monster")]
    [SerializeField]
    private int _resourceType;
    public int ResourceType => _resourceType;
    [Tooltip("资源 ID")]
    [SerializeField]
    private string _resourceId;
    public string ResourceId => _resourceId;

    [Tooltip("刷新间隔时间(毫秒)")]
    [SerializeField]
    private int _updateInterval;
    public int UpdateInterval => _updateInterval;
    [Tooltip("范围(半径)")]
    [SerializeField]
    private float _radius;
    public float Radius => _radius;

    [Tooltip("巡逻半径")]
    [SerializeField]
    private float _patrolRadius;
    public float PatrolRadius => _patrolRadius;

    [Tooltip("巡逻速度")]
    [SerializeField]
    private float _patrolSpd;
    public float PatrolSpd => _patrolSpd;
    public object GetServerData()
    {
        ResourcesPointData data = new();
        data.X = transform.position.x;
        data.Y = transform.position.y;
        data.Z = transform.position.z;
        data.ResourceType = _resourceType;
        data.ResourceId = _resourceId;
        data.UpdateInterval = _updateInterval;
        data.Radius = _radius;
        data.PatrolRadius = _patrolRadius;
        data.PatrolSpd = _patrolSpd;
        return data;
    }
}