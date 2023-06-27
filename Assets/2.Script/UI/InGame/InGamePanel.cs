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

        settingBtn.onClick.AddListener(() => inGameUI.TurnOnPanel(EInGamePanel.SETTING));
        reportBtn.onClick.AddListener(() => 
        {
            // TODO : only activated when the bodies is around the player
            inGameUI.TurnOnPanel(EInGamePanel.MEETING);
        });
    }

    #endregion Methods
}
