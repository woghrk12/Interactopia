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

    public override IEnumerator ActivatePanel(bool isEffect)
    {
        if (!gameObject.activeSelf) { gameObject.SetActive(true); }

        if (isEffect)
        {
            // TODO : implement panel effects
            yield return null;
        }

        yield return MoveToNextPanel();
    }

    public override IEnumerator DeactivePanel(bool isEffect)
    {
        if (isEffect)
        {
            // TODO : implement panel effects
            yield return null;
        }

        if (gameObject.activeSelf) { gameObject.SetActive(false); }
    }

    private IEnumerator MoveToNextPanel()
    {
        // TODO : add text animation and the function that which panel will be shown (InGame or Ending)
        yield return new WaitForSeconds(3f);

        inGameUI.TurnOnPanel(EInGamePanel.ENDING);
    }

    #endregion Methods
}
