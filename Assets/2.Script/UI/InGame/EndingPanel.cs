using System.Collections;
using UnityEngine;

public class EndingPanel : UIPanel
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

        // TODO : need to be manipulated by InGame Manager
        StartCoroutine(MoveToRoomPanel());
    }

    private IEnumerator MoveToRoomPanel()
    {
        yield return new WaitForSeconds(3f);

        inGameUI.TurnOnPanel(EInGamePanel.ROOM);
    }

    #endregion Methods
}
