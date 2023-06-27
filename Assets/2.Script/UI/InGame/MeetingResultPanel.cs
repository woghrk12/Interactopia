using System.Collections;
using UnityEngine;

public class MeetingResultPanel : UIPanel
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

        StartCoroutine(MoveToNextPanel());
    }

    private IEnumerator MoveToNextPanel()
    {
        // TODO : add text animation and the function that which panel will be shown (InGame or Ending)
        yield return new WaitForSeconds(3f);

        inGameUI.TurnOnPanel(EInGamePanel.ENDING);
    }

    #endregion Methods
}
