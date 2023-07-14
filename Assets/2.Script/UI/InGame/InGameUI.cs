using System.Collections;

public enum EInGamePanel { NONE = -1, ROOM, GAMESTART, INGAME, MEETING, MEETINGRESULT, ENDING, TEXTCHATTING, HOSTRULESETTING, GUESTRULESETTING, SETTING, LOADING, FADE, END }

public class InGameUI : UIBase
{
    #region Methods

    public override void InitBase()
    {
        base.InitBase();

        PopupPanel(EInGamePanel.ROOM);
    }

    public UIPanel GetPanel(EInGamePanel panel) { return uiPanelList[(int)panel]; }

    public void OpenPanel(EInGamePanel openPanel, EInGamePanel closePanel)
        => OpenPanel((int)openPanel, (int)closePanel);

    public void ClosePanel(EInGamePanel panel) => ClosePanel((int)panel);

    public void PopupPanel(EInGamePanel panel) => PopupPanel((int)panel);

    #endregion Methods
}
