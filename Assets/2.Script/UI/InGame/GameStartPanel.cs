using System.Collections;
using UnityEngine;

public class GameStartPanel : UIPanel
{
    #region Variables

    private InGameUI inGameUI = null;

    #endregion Variables

    #region Methods

    // TODO : need to make function to move to result panel after a certain amount of time

    public override void InitPanel(UIBase uiBase)
    {
        inGameUI = uiBase as InGameUI;
    }

    public override IEnumerator OnActivePanel()
    {
        // TODO : add condition to check player's camp
        // TODO : implement panel effects
        yield return null;
    }

    public override IEnumerator OnDeactivePanel()
    {
        // TODO : implement panel effects
        yield return null;
    }
    
    #endregion Methods
}
