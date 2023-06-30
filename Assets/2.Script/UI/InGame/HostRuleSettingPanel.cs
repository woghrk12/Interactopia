using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HostRuleSettingPanel : UIPanel
{
    #region Variables

    private InGameUI inGameUI = null;

    [SerializeField] private Image backgroundImg = null;
    [SerializeField] private Button closeBtn = null;

    #endregion Variables

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        inGameUI = uiBase as InGameUI;

        backgroundImg.GetComponent<Button>().onClick.AddListener(OnClickCloseBtn);
        closeBtn.onClick.AddListener(OnClickCloseBtn);
    }

    public void OnClickCloseBtn() { inGameUI.TurnOffPanel(EInGamePanel.HOSTRULESETTING); }

    #endregion Methods
}
