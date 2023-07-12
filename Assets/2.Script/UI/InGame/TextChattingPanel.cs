using System.Collections;
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

        backgroundImg.GetComponent<Button>().onClick.AddListener(OnClickCloseBtn);
        closeBtn.onClick.AddListener(OnClickCloseBtn);
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

    public void OnClickCloseBtn() { inGameUI.TurnOffPanel(EInGamePanel.TEXTCHATTING); }

    #endregion Event Methods
}
