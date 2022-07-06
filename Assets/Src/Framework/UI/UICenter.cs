using System.Collections.Generic;
using FairyGUI;
using UnityGameFramework.Runtime;
public partial class UICenter : GameFrameworkComponent
{
    public const string FORM_ASSET_PREFIX = "Assets/Res/Prefab/UI/";
    public const string UI_ASSET_PREFIX = "Assets/Res/Fairygui/";
    private void Start()
    {
        InitFont();
        InitConfig();
        InitPackage();
        InitFguiExtension();
    }

    public static void InitConfig()
    {
        DontDestroyOnLoad(Stage.inst.GetRenderCamera().gameObject);
        //init config
    }
}