using System.Collections;   
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

        settingBtn.onClick.AddListener(OnClickSettingBtn);
        textChattingBtn.onClick.AddListener(OnClickTextChattingBtn);
        ruleSettingBtn.onClick.AddListener(OnClickRuleSettingBtn);
        startBtn.onClick.AddListener(OnClickStartBtn);
    }

    public void OnClickSettingBtn() { inGameUI.TurnOnPanel(EInGamePanel.SETTING); }

    public void OnClickTextChattingBtn() { inGameUI.TurnOnPanel(EInGamePanel.TEXTCHATTING); }

    public void OnClickRuleSettingBtn()
    {
        // TODO : add condition whether the player is host or guest
        inGameUI.TurnOnPanel(EInGamePanel.HOSTRULESETTING);
    }

    public void OnClickStartBtn() { inGameUI.TurnOnPanel(EInGamePanel.GAMESTART, true); }

    public override IEnumerator OnActivePanel()
    {
        // TODO : implement panel effects
        yield return null;
    }

    public override IEnumerator OnDeactivePanel()
    {
        // TODO : implement panel effects
        yield return null;
    }

    #endregion Methods
}
