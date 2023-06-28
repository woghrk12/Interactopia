using System.Collections;
using UnityEngine;

public class GameStartPanel : UIPanel
{
    #region Variables

    private InGameUI inGameUI = null;

    #endregion Variables

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        inGameUI = uiBase as InGameUI;
    }

    public override void ActivatePanel()
    {
        base.ActivatePanel();

        // TODO : add condition to check player's camp

        // TODO : make ActivatePanel and DeactivatePanel functions Coroutine
        StartCoroutine(ShowPlayers());
    }

    private IEnumerator ShowPlayers()
    {
        yield return new WaitForSeconds(3f);

        inGameUI.TurnOnPanel(EInGamePanel.INGAME);
    }

    #endregion Methods
}
