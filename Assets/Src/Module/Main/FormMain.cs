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

        FairyGUI.GTextInput rowInput = GCom.GetChild("rowInput").asTextInput;
        FairyGUI.GTextInput colInput = GCom.GetChild("colInput").asTextInput;
        FairyGUI.GTextInput roomInput = GCom.GetChild("roomInput").asTextInput;

        FairyGUI.GButton btnAnswer = GCom.GetChild("btnAnswer").asButton;
        btnAnswer.AddEventListener("onTouchEnd", () =>
        {
            int row = int.Parse(rowInput.text);
            int col = int.Parse(colInput.text);
            Egret.QuizAnswerAction.Req(row, col);
        });
        FairyGUI.GButton btnRoom = GCom.GetChild("btnRoom").asButton;
        btnRoom.AddEventListener("onTouchEnd", () =>
        {
            Egret.QuizCreateRoomAction.Req(roomInput.text);
        });
    }
}