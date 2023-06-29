using System.Collections;

public enum ETitleUIPanel { NONE = -1, START, LOBBY, CREATEROOM, PUBLICJOIN, PRIVATEJOIN, SETTING, LOADING, FADE, END }

public class TitleUI : UIBase
{
    #region Methods

    public override void InitBase()
    {
        base.InitBase();

        if (NetworkManager.IsInitialized) { TurnOnPanel(ETitleUIPanel.START, true); }
        else { TurnOnPanel(ETitleUIPanel.LOADING); }
    }

    public UIPanel GetPanel(ETitleUIPanel idxPanel) { return uiPanelList[(int)idxPanel]; }

    public void TurnOnPanel(ETitleUIPanel panel, bool hasOnEffect = false, bool hasOffEffect = false)
        => StartCoroutine(TurnOnUIPanel((int)panel, hasOnEffect, hasOffEffect));

    public void TurnOffPanel(ETitleUIPanel panel, bool hasOffEffect = false)
        => StartCoroutine(TurnOffUIPanel((int)panel, hasOffEffect));

    #endregion Methods
}
