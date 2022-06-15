using System;
using Bian;
using UnityEngine;
using Google.Protobuf.Collections;

namespace WorldMap
{
    public class WorldMapModule : MonoBehaviour
    {
        public Action<RepeatedField<BigWorldLogoInfo>> OnVipLandLogoUpdated = delegate { };
        public Action<RepeatedField<PlayerLocInfo>> OnPlayerLocUpdated = delegate { };
        [SerializeField]
        private float _timeToReqPlayerLoc = 3.0f;
        private float _curTimeToReqPlayerLoc = 0.0f;
        private bool _isReqPlayerLoc = false;

        public void ReqLogoData()
        {
            AllVipLandLogoAction.Req();
        }

        private void ReqPlayerLoc()
        {
            AllPlayerLocAction.Req();
        }

        public void StartReqPlayerLoc()
        {
            _isReqPlayerLoc = true;
        }

        public void StopReqPlayerLoc()
        {
            _isReqPlayerLoc = false;
        }

        private void Update()
        {
            _curTimeToReqPlayerLoc += Time.deltaTime;
            if (_isReqPlayerLoc && _curTimeToReqPlayerLoc >= _timeToReqPlayerLoc)
            {
                _curTimeToReqPlayerLoc = 0.0f;
                ReqPlayerLoc();
            }
        }
    }
}