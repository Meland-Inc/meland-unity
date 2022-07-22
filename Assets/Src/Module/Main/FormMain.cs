/// <summary>
/// 主界面
/// </summary>
public class FormMain : FGUIForm
{
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        MLog.Debug(eLogTag.ui, userData);
        _ = GCom.AddSubUILogic<ComMainBagShortcut>();
        _ = GCom.AddSubUILogic<ComMainBigWorld>("comMainBigWorld");

        FairyGUI.GTextInput rowInput = GCom.GetChild("rowInput").asTextInput;
        FairyGUI.GTextInput colInput = GCom.GetChild("colInput").asTextInput;
        FairyGUI.GTextInput roomInput = GCom.GetChild("roomInput").asTextInput;

        FairyGUI.GButton btnAnswer = GCom.GetChild("btnAnswer").asButton;
        btnAnswer.onTouchEnd.Add(() =>
        {
            int row = int.Parse(rowInput.text);
            int col = int.Parse(colInput.text);
            Runtime.QuizAnswerAction.Req(row, col);
        });
        FairyGUI.GButton btnRoom = GCom.GetChild("btnRoom").asButton;
        btnRoom.onTouchEnd.Add(() =>
        {
            Runtime.QuizCreateRoomAction.Req(roomInput.text);
        });

        GCom.GetChild("comMainBigWorld").asCom.GetChild("comRoleInfo").onClick.Add(() =>
        {
            SceneModule.Craft.OpenFormPlayerInfo();
        });
    }
}