using System.Collections;

public enum EInGamePanel { NONE = -1, ROOM, GAMESTART, INGAME, MEETING, MEETINGRESULT, ENDING, TEXTCHATTING, HOSTRULESETTING, GUESTRULESETTING, SETTING, LOADING, FADE, END }

public class InGameUI : UIBase
{
    #region Methods

    public override void InitBase()
    {
        base.InitBase();

        TurnOnPanel((int)EInGamePanel.ROOM);
    }

    public UIPanel GetPanel(EInGamePanel idxPanel) { return uiPanelList[(int)idxPanel]; }

    public void TurnOnPanel(EInGamePanel panel) => TurnOnUIPanel((int)panel);

    public void TurnOffPanel(EInGamePanel panel) => TurnOffUIPanel((int)panel);

    #endregion Methods
}
