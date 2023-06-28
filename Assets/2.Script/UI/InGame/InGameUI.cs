using System.Collections;

public enum EInGamePanel { NONE = -1, ROOM, GAMESTART, INGAME, MEETING, MEETINGRESULT, ENDING, TEXTCHATTING, HOSTRULESETTING, GUESTRULESETTING, SETTING, FADE, END }

public class InGameUI : UIBase
{
    #region Unity Events

    protected override void Start()
    {
        base.Start();

        TurnOnPanel((int)EInGamePanel.ROOM);
    }

    #endregion Unity Events

    #region Methods

    public UIPanel GetPanel(EInGamePanel idxPanel) { return uiPanelList[(int)idxPanel]; }

    public void TurnOnPanel(EInGamePanel panel, bool hasOnEffect = false, bool hasOffEffect = false)
        => StartCoroutine(TurnOnUIPanel((int)panel, hasOnEffect, hasOffEffect));

    public void TurnOffPanel(EInGamePanel panel, bool hasOffEffect = false)
        => StartCoroutine(TurnOffUIPanel((int)panel, hasOffEffect));

    #endregion Methods
}
