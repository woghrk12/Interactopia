using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ETitleUIPanel { NONE = -1, START, LOBBY, CREATEROOM, PUBLICJOIN, PRIVATEJOIN, SETTING, FADE, END }

public class TitleUI : UIBase
{
    #region Unity Events

    protected override void Start()
    {
        base.Start();

        TurnOnUIPanel((int)ETitleUIPanel.START);
    }

    #endregion Unity Events

    #region Methods

    public UIPanel GetPanel(ETitleUIPanel idxPanel) { return uiPanelList[(int)idxPanel]; }

    public void TurnOnPanel(ETitleUIPanel panel) => TurnOnUIPanel((int)panel);

    public void TurnOffPanel(ETitleUIPanel panel) => TurnOffUIPanel((int)panel);
    #endregion Methods
}
