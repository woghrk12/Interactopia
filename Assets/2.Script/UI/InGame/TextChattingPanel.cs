using UnityEngine;
using UnityEngine.UI;

public class TextChattingPanel : UIPanel
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

        backgroundImg.GetComponent<Button>().onClick.AddListener(() => inGameUI.TurnOffPanel(EInGamePanel.TEXTCHATTING));
        closeBtn.onClick.AddListener(() => inGameUI.TurnOffPanel(EInGamePanel.TEXTCHATTING));
    }

    #endregion Methods
}
