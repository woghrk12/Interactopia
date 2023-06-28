using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InGamePanel : UIPanel
{
    #region Variables

    private InGameUI inGameUI = null;

    [SerializeField] private Button settingBtn = null;
    [SerializeField] private Button reportBtn = null;

    #endregion Variables

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        inGameUI = uiBase as InGameUI;

        settingBtn.onClick.AddListener(OnClickSettingBtn);
        reportBtn.onClick.AddListener(OnClickReportBtn);
    }

    public void OnClickSettingBtn() { StartCoroutine(inGameUI.TurnOnPanel(EInGamePanel.SETTING)); }

    public void OnClickReportBtn() 
    {
        // TODO : only activated when the bodies is around the player
        StartCoroutine(inGameUI.TurnOnPanel(EInGamePanel.MEETING));
    }

    public override IEnumerator ActivatePanel(bool isEffect)
    {
        if (!gameObject.activeSelf) { gameObject.SetActive(true); }

        if (isEffect)
        {
            // TODO : implement panel effects
            yield return null;
        }
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

    #endregion Methods
}
