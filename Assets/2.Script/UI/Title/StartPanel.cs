using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : UIPanel
{
    #region Variables

    private TitleUI titleUI = null;

    [SerializeField] private Image titleImg = null;
    [SerializeField] private Button startBtn = null;
    [SerializeField] private Button settingBtn = null;
    [SerializeField] private Button authBtn = null;

    #endregion Variables

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        titleUI = uiBase as TitleUI;

        startBtn.onClick.AddListener(OnClickStartBtn);
        settingBtn.onClick.AddListener(OnClickSettingBtn);
        authBtn.onClick.AddListener(OnClickAuthBtn);
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

    public void OnClickStartBtn() => titleUI.TurnOnPanel(ETitleUIPanel.LOBBY);

    public void OnClickSettingBtn() => titleUI.TurnOnPanel(ETitleUIPanel.SETTING); 

    public void OnClickAuthBtn() => titleUI.TurnOnPanel(ETitleUIPanel.AUTH);

    #endregion Event Methods
}
