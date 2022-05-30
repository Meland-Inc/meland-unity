/*
 * @Author: xiang huan
 * @Date: 2022-05-28 09:24:00
 * @LastEditTime: 2022-05-29 17:09:35
 * @LastEditors: xiang huan
 * @Description: 白鹭游戏模块
 * @FilePath: /meland-unity/Assets/Src/Framework/Egret/EgretGameCenter.cs
 * 
 */
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


    private void Start()
    {
        _ = initWebViewAsync();
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

    private async UniTask initWebViewAsync()
    {
        if (_canvasWebView != null)
        {
            return;
        }
        _canvasWebView = CanvasWebViewPrefab.Instantiate();
        GameObject canvas = GameObject.Find("Canvas");
        _canvasWebView.transform.parent = canvas.transform;
        RectTransform rectTransform = _canvasWebView.transform as RectTransform;
        rectTransform.anchoredPosition3D = Vector3.zero;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;
        _canvasWebView.transform.localScale = Vector3.one;
        await _canvasWebView.WaitUntilInitialized();
        _canvasWebView.WebView.LoadUrl("http://play.melandworld.com/index_planet?developMode=1");
        _canvasWebView.Native2DModeEnabled = true;
        _canvasWebView.NativeOnScreenKeyboardEnabled = true;
        _canvasWebView.LogConsoleMessages = true;
        // _canvasWebView.WebView.LoadProgressChanged += async (sender, eventArgs) =>
        // {
        //     if (eventArgs.Type == ProgressChangeType.Finished)
        //     {
        //         var headerText = await _canvasWebView.WebView.ExecuteJavaScript(@"
        //             document.body.style.backgroundColor='transparent';
        //             var headHTML = document.getElementsByTagName('head')[0].innerHTML;
        //             headHTML += < meta name = 'transparent' content = 'true' >;
        //             document.getElementsByTagName('head')[0].innerHTML = headHTML;
        //         ");
        //         Debug.Log("H1 text: " + headerText);
        //     }
        // };
        SetUpHardwareKeyboard();
        _egretMsgNetwork = new(_canvasWebView);
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
        _egretMsgNetwork.ExecuteSend(action);
    }

}
