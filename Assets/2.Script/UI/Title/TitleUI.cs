using System.Collections;

public enum ETitleUIPanel { NONE = -1, START, LOBBY, CREATEROOM, PUBLICJOIN, PRIVATEJOIN, SETTING, FADE, END }

public class TitleUI : UIBase
{
    #region Unity Events

    protected override void Start()
    {
        base.Start();

        StartCoroutine(TurnOnPanel(ETitleUIPanel.START, true));
    }

    #endregion Unity Events

    #region Methods

    public UIPanel GetPanel(ETitleUIPanel idxPanel) { return uiPanelList[(int)idxPanel]; }

    public IEnumerator TurnOnPanel(ETitleUIPanel panel, bool hasOnEffect = false, bool hasOffEffect = false)
        => TurnOnUIPanel((int)panel, hasOnEffect, hasOffEffect);

    public IEnumerator TurnOffPanel(ETitleUIPanel panel, bool hasOffEffect = false)
        => TurnOffUIPanel((int)panel, hasOffEffect);

    #endregion Methods
}
