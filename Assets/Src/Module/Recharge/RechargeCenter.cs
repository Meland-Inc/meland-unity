using System;
/*
 * @Author: mangit
 * @LastEditors: mangit
 * @Description: 充值中心
 * @Date: 2022-07-07 10:44:30
 * @FilePath: /Assets/Src/Module/Recharge/RechargeCenter.cs
 */
using UnityGameFramework.Runtime;
using Cysharp.Threading.Tasks;
using Runtime;

public class RechargeCenter : GameFrameworkComponent
{
    public Action<int> OnRechargeMeld = delegate { };
    public Action<int> OnRechargeMeldSuccess = delegate { };
    public Action OnRechargeMeldFailed = delegate { };
    public Action<bool> OnRechargeMeldStatusChanged = delegate { };
    private bool _isRechargeMelding = false;
    public bool IsMeldRecharging
    {
        get => _isRechargeMelding;
        private set
        {
            _isRechargeMelding = value;
            OnRechargeMeldStatusChanged.Invoke(value);
        }
    }

    private UniTaskCompletionSource _meldRechargeTask;
    private int _meldRechargeBlockNum;

    public UniTask RechargeMeld(int count)
    {
        if (IsMeldRecharging)
        {
            return UniTask.FromException(new Exception("meld is recharging"));
        }

        MLog.Info(eLogTag.recharge, $"recharge meld {count}");
        IsMeldRecharging = true;
        _meldRechargeTask = new UniTaskCompletionSource();
        RechargeTokenAction.Req(count).SetCB(OnMeldRechargeResponse, OnMeldRechargeError);
        OnRechargeMeld.Invoke(count);
        return _meldRechargeTask.Task;
    }

    private void OnMeldRechargeResponse(RechargeTokenResponse rsp)
    {
        MLog.Info(eLogTag.recharge, $"recharge response,block num:{rsp.BlockNum}");
        _meldRechargeBlockNum = rsp.BlockNum;
    }

    private void OnMeldRechargeError(int errCode, string errMsg)
    {
        MLog.Info(eLogTag.recharge, $"recharge meld error {errCode} {errMsg}");
        IsMeldRecharging = false;
        _ = _meldRechargeTask.TrySetException(new Exception(errMsg));
        OnRechargeMeldFailed.Invoke();
    }

    public void RechargeSuccess(int blockNum)
    {
        if (blockNum == _meldRechargeBlockNum)
        {
            MLog.Info(eLogTag.recharge, $"recharge meld success {blockNum}");
            IsMeldRecharging = false;
            _ = _meldRechargeTask.TrySetResult();
            OnRechargeMeldSuccess.Invoke(blockNum);
        }
    }
}