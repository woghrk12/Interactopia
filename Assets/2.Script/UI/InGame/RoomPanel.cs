using UnityEngine;
using UnityEngine.UI;

public class RoomPanel : UIPanel
{
    #region Variables

    private InGameUI inGameUI = null;

    [SerializeField] private Button settingBtn = null;
    [SerializeField] private Button textChattingBtn = null;
    [SerializeField] private Button ruleSettingBtn = null;
    [SerializeField] private Button startBtn = null;

    #endregion Variables

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        inGameUI = uiBase as InGameUI;

        settingBtn.onClick.AddListener(() => inGameUI.TurnOnPanel(EInGamePanel.SETTING));
        textChattingBtn.onClick.AddListener(() => inGameUI.TurnOnPanel(EInGamePanel.TEXTCHATTING));

        // TODO : add condition whether the player is host or guest
        ruleSettingBtn.onClick.AddListener(() => { inGameUI.TurnOnPanel(EInGamePanel.HOSTRULESETTING); });
        startBtn.onClick.AddListener(() => inGameUI.TurnOnPanel(EInGamePanel.GAMESTART));
    }

    #endregion Methods
}
