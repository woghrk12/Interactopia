using System.Collections;
using UnityEngine;

public class MeetingResultPanel : UIPanel
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

    #endregion Methods

    #region Override Methods

    public override IEnumerator ActiveAnimation()
    {
        yield break;
    }

    public override IEnumerator DeactiveAnimation()
    {
        yield break;
    }

    #endregion Override Methods
}
