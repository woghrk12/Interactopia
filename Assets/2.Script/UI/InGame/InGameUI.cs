using System.Collections;

public enum EInGamePanel { NONE = -1, ROOM, GAMESTART, INGAME, MEETING, MEETINGRESULT, ENDING, TEXTCHATTING, HOSTRULESETTING, GUESTRULESETTING, SETTING, FADE, END }

public class InGameUI : UIBase
{
    #region Unity Events

    protected override void Start()
    {
        base.Start();

        StartCoroutine(TurnOnPanel((int)EInGamePanel.ROOM));
    }

    #endregion Unity Events

    #region Methods

    public UIPanel GetPanel(EInGamePanel idxPanel) { return uiPanelList[(int)idxPanel]; }

    public IEnumerator TurnOnPanel(EInGamePanel panel, bool hasOnEffect = false, bool hasOffEffect = false) 
        => TurnOnUIPanel((int)panel, hasOnEffect, hasOffEffect);

    public IEnumerator TurnOffPanel(EInGamePanel panel, bool hasOffEffect = false) 
        => TurnOffUIPanel((int)panel, hasOffEffect);

    #endregion Methods
}
