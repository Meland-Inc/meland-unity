using UnityEngine;

public class MoveNetRequest : MonoBehaviour
{
    private const float REQ_MOVE_INTERVAL = 0.5f;

    private float _lastReqTime = 0;

    private void Start()
    {
        _lastReqTime = Time.realtimeSinceStartup;
    }

    private void Update()
    {
        if (Time.realtimeSinceStartup - _lastReqTime > REQ_MOVE_INTERVAL)
        {
            _lastReqTime = Time.realtimeSinceStartup;
            TeleportAction.Req(transform.position);//TODO:需要改成正式的移动协议  现在用移动协议 服务器会同步移动但是不会同步实体有问题
        }
    }
}