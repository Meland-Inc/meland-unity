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
            UpdateSelfLocationAction.Req(transform.position);
        }
    }
}