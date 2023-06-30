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

    #endregion Variables

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        titleUI = uiBase as TitleUI;

        startBtn.onClick.AddListener(OnClickStartBtn);
        settingBtn.onClick.AddListener(OnClickSettingBtn);
    }

    public void OnClickStartBtn() { titleUI.TurnOnPanel(ETitleUIPanel.LOBBY); }

    public void OnClickSettingBtn() { titleUI.TurnOnPanel(ETitleUIPanel.SETTING); }

    #endregion Methods
}
