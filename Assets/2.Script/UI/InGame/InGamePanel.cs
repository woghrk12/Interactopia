using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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

    #endregion Methods

    #region Override Methods

    public override Sequence ActiveAnimation()
    {
        return DOTween.Sequence();
    }

    public override Sequence DeactiveAnimation()
    {
        return DOTween.Sequence();
    }

    #endregion Override Methods

    #region Event Methods

    public void OnClickSettingBtn() { inGameUI.TurnOnPanel(EInGamePanel.SETTING); }

    public void OnClickReportBtn() 
    {
        // TODO : only activated when the bodies is around the player
        inGameUI.TurnOnPanel(EInGamePanel.MEETING);
    }

    #endregion Event Methods
}
