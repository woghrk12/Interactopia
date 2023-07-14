using System.Collections;
using UnityEngine;

public class GameStartPanel : UIPanel
{
    #region Variables

    private InGameUI inGameUI = null;

    #endregion Variables

    #region Methods

    // TODO : add condition to check player's camp

    public override void InitPanel(UIBase uiBase)
    {
        inGameUI = uiBase as InGameUI;
    }
    
    #endregion Methods
}
