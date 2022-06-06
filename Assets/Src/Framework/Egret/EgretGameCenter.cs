/*
 * @Author: xiang huan
 * @Date: 2022-05-28 09:24:00
 * @LastEditTime: 2022-06-06 11:40:13
 * @LastEditors: xiang huan
 * @Description: 白鹭游戏模块
 * @FilePath: /meland-unity/Assets/Src/Framework/Egret/EgretGameCenter.cs
 * 
 */
using System.Collections.Generic;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityGameFramework.Runtime;
using Vuplex.WebView;
using Vuplex.WebView.Demos;

public class EgretGameCenter : GameFrameworkComponent
{
    private CanvasWebViewPrefab _canvasWebView;
    HardwareKeyboardListener _hardwareKeyboardListener;
    private EgretMsgNetwork _egretMsgNetwork;
    private bool _isEgretReady;
    private readonly List<IEgretMsgAction> _sendMsgActionList = new();
    private Dictionary<EgretDefine.eEgretEnableMode, bool> _enableModeMap = new();
    protected override void Awake()
    {
        base.Awake();
#if DEBUG
        Web.EnableRemoteDebugging();
#endif
    }
    private void Start()
    {
        _ = InitWebViewAsync();
    }

    private void OnDestroy()
    {
        if (_canvasWebView)
        {
            _canvasWebView.Destroy();
            _canvasWebView = null;
        }
        if (_egretMsgNetwork != null)
        {
            _egretMsgNetwork.Destroy();
            _egretMsgNetwork = null;
        }
    }
    private void Update()
    {
        if (_egretMsgNetwork != null)
        {
            _egretMsgNetwork.Update(Time.deltaTime, Time.unscaledDeltaTime);
        }
    }

    private async UniTask InitWebViewAsync()
    {
        if (_canvasWebView != null)
        {
            return;
        }
        _isEgretReady = false;
        _sendMsgActionList.Clear();
        _enableModeMap.Clear();

        _canvasWebView = CanvasWebViewPrefab.Instantiate();
        GameObject canvas = GameObject.Find("Canvas");
        _canvasWebView.transform.parent = canvas.transform;
        RectTransform rectTransform = _canvasWebView.transform as RectTransform;
        rectTransform.anchoredPosition3D = Vector3.zero;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;
        _canvasWebView.transform.localScale = Vector3.one;
        await _canvasWebView.WaitUntilInitialized();
        _canvasWebView.WebView.LoadUrl(URLConfig.EGRET_GAME_ADDRESS);
        _canvasWebView.Native2DModeEnabled = true;
        _canvasWebView.NativeOnScreenKeyboardEnabled = true;
        _canvasWebView.LogConsoleMessages = true;
        _canvasWebView.DragMode = DragMode.DragWithinPage;
        _canvasWebView.Visible = false;
        _canvasWebView.WebView.UrlChanged += UrlChanged;
        SetUpHardwareKeyboard();
        _egretMsgNetwork = new(_canvasWebView);
    }
    private void UrlChanged(object sender, UrlChangedEventArgs eventArgs)
    {
        if (URLConfig.EGRET_GAME_ADDRESS.Equals(eventArgs.Url))
        {
            EnableMode(EgretDefine.eEgretEnableMode.Login, false);
        }
        else
        {
            EnableMode(EgretDefine.eEgretEnableMode.Login, true);
        }
    }
    private void SetUpHardwareKeyboard()
    {
        _hardwareKeyboardListener = HardwareKeyboardListener.Instantiate();
        _hardwareKeyboardListener.KeyDownReceived += (sender, eventArgs) =>
        {
            if (_canvasWebView.WebView is IWithKeyDownAndUp webViewWithKeyDown)
            {
                webViewWithKeyDown.KeyDown(eventArgs.Value, eventArgs.Modifiers);
            }
            else
            {
                _canvasWebView.WebView.SendKey(eventArgs.Value);
            }
        };
        _hardwareKeyboardListener.KeyUpReceived += (sender, eventArgs) =>
        {
            IWithKeyDownAndUp webViewWithKeyUp = _canvasWebView.WebView as IWithKeyDownAndUp;
            webViewWithKeyUp?.KeyUp(eventArgs.Value, eventArgs.Modifiers);
        };
    }
    public void SendEgretMsg(IEgretMsgAction action)
    {
        if (_isEgretReady)
        {
            _egretMsgNetwork.ExecuteSend(action);
        }
        else
        {
            _sendMsgActionList.Add(action);
        }
    }

    public void EgretReady()
    {
        _isEgretReady = true;
        SendMsgActionList();
    }

    private void SendMsgActionList()
    {
        foreach (IEgretMsgAction action in _sendMsgActionList)
        {
            _egretMsgNetwork.ExecuteSend(action);
        }
        _sendMsgActionList.Clear();
    }

    public void EnableMode(EgretDefine.eEgretEnableMode mode, bool enable)
    {
        if (_enableModeMap.ContainsKey(mode))
        {
            _enableModeMap[mode] = enable;
        }
        else
        {
            _enableModeMap.Add(mode, enable);
        }
        bool visible = false;
        foreach (KeyValuePair<EgretDefine.eEgretEnableMode, bool> item in _enableModeMap)
        {
            if (item.Value)
            {
                visible = item.Value;
                break;
            }
        }
        _canvasWebView.Visible = visible;
        Input.imeCompositionMode = visible ? IMECompositionMode.On : IMECompositionMode.Auto;
        _hardwareKeyboardListener.enabled = visible;
    }

}
