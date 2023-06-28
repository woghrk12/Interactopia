public enum EInGamePanel { NONE = -1, ROOM, GAMESTART, INGAME, MEETING, MEETINGRESULT, ENDING, TEXTCHATTING, HOSTRULESETTING, GUESTRULESETTING, SETTING, FADE, END }

public class InGameUI : UIBase
{
    #region Unity Events

    protected override void Start()
    {
        base.Start();

        TurnOnUIPanel((int)EInGamePanel.ROOM);
    }

    #endregion Unity Events

    #region Methods

    public UIPanel GetPanel(EInGamePanel idxPanel) { return uiPanelList[(int)idxPanel]; }

    public void TurnOnPanel(EInGamePanel panel) => TurnOnUIPanel((int)panel);

    public void TurnOffPanel(EInGamePanel panel) => TurnOffUIPanel((int)panel);

    #endregion Methods
}
