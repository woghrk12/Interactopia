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

        settingBtn.onClick.AddListener(OnClickSettingBtn);
    }

    public void OnClickSettingBtn() { StartCoroutine(inGameUI.TurnOnPanel(EInGamePanel.SETTING)); }

    public override IEnumerator ActivatePanel(bool isEffect)
    {
        if (!gameObject.activeSelf) { gameObject.SetActive(true); }

        if (isEffect)
        {
            // TODO : implement panel effects
            yield return null;
        }

        yield return MoveToResultPanel();
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

    private IEnumerator MoveToResultPanel()
    {
        // TODO : need to make function to move to result panel when all the players make decision or discussion time is over
        yield return new WaitForSeconds(10f);

        inGameUI.TurnOnPanel(EInGamePanel.MEETINGRESULT);
    }

    #endregion Methods
}
