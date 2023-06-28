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

    public void OnClickSettingBtn() { StartCoroutine(inGameUI.TurnOnPanel(EInGamePanel.SETTING)); }

    public void OnClickTextChattingBtn() { StartCoroutine(inGameUI.TurnOnPanel(EInGamePanel.TEXTCHATTING)); }

    public void OnClickRuleSettingBtn()
    {
        // TODO : add condition whether the player is host or guest
        StartCoroutine(inGameUI.TurnOnPanel(EInGamePanel.HOSTRULESETTING));
    }

    public void OnClickStartBtn() { StartCoroutine(inGameUI.TurnOnPanel(EInGamePanel.GAMESTART)); }

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
