using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ETitleUIPanel { NONE = -1, TITLE, LOBBY, CREATEROOM, PUBLICJOIN, PRIVATEJOIN, END }

public class TitleUI : UIBase
{
    #region Methods

    public override void Init()
    {
        base.Init();

        TurnOnUIPanel((int)ETitleUIPanel.TITLE);
    }

    public UIPanel GetPanel(ETitleUIPanel idxPanel) { return uiPanelList[(int)idxPanel]; }

    #endregion Methods
}
