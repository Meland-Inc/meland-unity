/*
 * @Author: xiang huan
 * @Date: 2022-05-28 09:24:00
 * @LastEditTime: 2022-06-15 20:13:27
 * @LastEditors: xiang huan
 * @Description: runtime游戏模块
 * @FilePath: /meland-unity/Assets/Src/Framework/Runtime/RuntimeGameCenter.cs
 * 
 */
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityGameFramework.Runtime;
using Vuplex.WebView;
using Vuplex.WebView.Demos;

public class RuntimeGameCenter : GameFrameworkComponent
{
    private CanvasWebViewPrefab _canvasWebView;
    private HardwareKeyboardListener _hardwareKeyboardListener;
    private bool _isWebReady;
    private readonly List<string> _sendMsgList = new();
    private readonly Dictionary<RuntimeDefine.eEgretEnableMode, bool> _enableModeMap = new();
    protected override void Awake()
    {
        base.Awake();
#if DEBUG
        Web.EnableRemoteDebugging();
#endif
        Message.WebReady += WebReady;
    }
    private void Start()
    {
        _ = InitWebViewAsync();
    }

    private void OnDestroy()
    {
        Message.WebReady -= WebReady;
        if (_canvasWebView)
        {
            _canvasWebView.Destroy();
            _canvasWebView = null;
        }
    }

    private async UniTask InitWebViewAsync()
    {
        if (_canvasWebView != null)
        {
            return;
        }
        _isWebReady = false;
        _sendMsgList.Clear();
        _enableModeMap.Clear();
        try
        {
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
            _canvasWebView.Visible = true;
            _canvasWebView.WebView.UrlChanged += UrlChanged;
            _canvasWebView.WebView.MessageEmitted += OnMessageEmitted;
            SetUpHardwareKeyboard();
            EnableMode(RuntimeDefine.eEgretEnableMode.Login, true);
        }
        catch (System.Exception)
        {
            MLog.Error(eLogTag.runtime, $"InitWebViewAsync Error");
            throw;
        }
    }
    private void UrlChanged(object sender, UrlChangedEventArgs eventArgs)
    {
        // if (URLConfig.EGRET_GAME_ADDRESS.Equals(eventArgs.Url))
        // {
        //     EnableMode(RuntimeDefine.eEgretEnableMode.Login, false);
        // }
        // else
        // {
        //     EnableMode(RuntimeDefine.eEgretEnableMode.Login, true);
        // }
    }

    private void OnMessageEmitted(object sender, EventArgs<string> e)
    {
        Message.RuntimeMessageEmitted?.Invoke(e.Value);
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
    public void SendMsg(string msg)
    {
        if (_isWebReady && _canvasWebView != null)
        {
            _canvasWebView.WebView.PostMessage(msg);
        }
        else
        {
            _sendMsgList.Add(msg);
        }
    }

    public void WebReady(bool isReady)
    {
        _isWebReady = isReady;
        if (_isWebReady)
        {
            SendMsgList();
        }
    }

    private void SendMsgList()
    {
        foreach (string msg in _sendMsgList)
        {
            SendMsg(msg);
        }
        _sendMsgList.Clear();
    }

    public void EnableMode(RuntimeDefine.eEgretEnableMode mode, bool enable)
    {
        if (_enableModeMap.ContainsKey(mode))
        {
            _enableModeMap[mode] = enable;
        }
        else
        {
            _enableModeMap.Add(mode, enable);
        }

        if (_canvasWebView == null)
        {
            return;
        }

        bool visible = false;
        foreach (KeyValuePair<RuntimeDefine.eEgretEnableMode, bool> item in _enableModeMap)
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
