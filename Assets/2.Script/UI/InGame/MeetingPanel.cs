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

    #region Event Methods

    public void OnClickSettingBtn() { inGameUI.TurnOnPanel(EInGamePanel.SETTING); }

    #endregion Event Methods
}
