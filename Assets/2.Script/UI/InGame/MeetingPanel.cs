using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MeetingPanel : UIPanel
{
    #region Variables

    private InGameUI inGameUI = null;

    [SerializeField] private Button settingBtn = null;

    #endregion Variables

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        inGameUI = uiBase as InGameUI;

        settingBtn.onClick.AddListener(() => inGameUI.TurnOnPanel(EInGamePanel.SETTING));
    }

    public override void ActivatePanel()
    {
        base.ActivatePanel();

        StartCoroutine(MoveToResultPanel());
    }

    private IEnumerator MoveToResultPanel()
    {
        // TODO : need to make function to move to result panel when all the players make decision or discussion time is over
        yield return new WaitForSeconds(10f);

        inGameUI.TurnOnPanel(EInGamePanel.MEETINGRESULT);
    }

    #endregion Methods
}
