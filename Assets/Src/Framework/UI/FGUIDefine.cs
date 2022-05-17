using System;
namespace FGUIDefine
{

    public enum eFormID : byte//主界面窗口ID
    {
        main = 0,
    }

    public static class UIGroups
    {
        public static string Form = "Form";
        public static string Tootip = "Tootip";
        public static string Toast = "toast";
        public static string Dialog = "Dialog";
        public static string Alert = "Alert";
        public static string Log = "Log";
    }
}