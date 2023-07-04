using UnityEngine;

public enum ETitleUIPanel { NONE = -1, START, LOBBY, CREATEROOM, PUBLICJOIN, PRIVATEJOIN, SETTING, LOADING, FADE, END }

public class TitleUI : UIBase
{
    #region Methods

    public override void InitBase()
    {
        base.InitBase();

        if (NetworkManager.IsInitialized) { TurnOnPanel(ETitleUIPanel.START); }
        else { TurnOnPanel(ETitleUIPanel.LOADING); }
    }

    public UIPanel GetPanel(ETitleUIPanel idxPanel) { return uiPanelList[(int)idxPanel]; }

    public void TurnOnPanel(ETitleUIPanel panel) => TurnOnUIPanel((int)panel);

    public void TurnOffPanel(ETitleUIPanel panel) => TurnOffUIPanel((int)panel);

    #endregion Methods
}
