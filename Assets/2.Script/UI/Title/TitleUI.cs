using System.Collections;

public enum ETitleUIPanel { NONE = -1, START, LOBBY, CREATEROOM, PUBLICJOIN, PRIVATEJOIN, SETTING, FADE, END }

public class TitleUI : UIBase
{
    #region Unity Events

    protected override void Start()
    {
        base.Start();

        TurnOnPanel(ETitleUIPanel.START, true);
    }

    #endregion Unity Events

    #region Methods

    public UIPanel GetPanel(ETitleUIPanel idxPanel) { return uiPanelList[(int)idxPanel]; }

    public void TurnOnPanel(ETitleUIPanel panel, bool hasOnEffect = false, bool hasOffEffect = false)
        => StartCoroutine(TurnOnUIPanel((int)panel, hasOnEffect, hasOffEffect));

    public void TurnOffPanel(ETitleUIPanel panel, bool hasOffEffect = false)
        => StartCoroutine(TurnOffUIPanel((int)panel, hasOffEffect));

    #endregion Methods
}
