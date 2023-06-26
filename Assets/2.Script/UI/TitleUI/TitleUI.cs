using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ETitleUIPanel { NONE = -1, START, LOBBY, CREATEROOM, PUBLICJOIN, PRIVATEJOIN, FADE, END }

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

    #endregion Methods
}
