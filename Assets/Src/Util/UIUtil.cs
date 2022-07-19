using FairyGUI;

public static class UIUtil
{
    public static void SetBtnEnable(GButton btn, bool enable)
    {
        btn.touchable = enable;
        btn.grayed = !enable;
    }

    public static void SetBtnLoadingStatus(GButton btn, bool isLoading)
    {
        Controller ctrl = btn.GetController("ctrlLoading");
        if (ctrl == null)
        {
            MLog.Error(eLogTag.ui, "SetBtnLoadingStatus: ctrlLoading is null");
            return;
        }

        ctrl.SetSelectedPage(isLoading ? "loading" : "normal");
        btn.touchable = !isLoading && !btn.grayed;
    }
}