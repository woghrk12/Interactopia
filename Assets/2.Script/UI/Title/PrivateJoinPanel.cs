using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrivateJoinPanel : UIPanel
{
    #region Variables

    private TitleUI titleUI = null;

    [SerializeField] private Image backgroundImg = null;
    [SerializeField] private Button closeBtn = null;
    [SerializeField] private Button enterBtn = null;

    #endregion Variables

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        titleUI = uiBase as TitleUI;

        backgroundImg.GetComponent<Button>().onClick.AddListener(() => titleUI.TurnOffPanel(ETitleUIPanel.PRIVATEJOIN));
        closeBtn.onClick.AddListener(() => titleUI.TurnOffPanel(ETitleUIPanel.SETTING));
        enterBtn.onClick.AddListener(() => SceneManager.LoadScene(1));
    }

    public override void ActivatePanel()
    {
        base.ActivatePanel();
    }

    public override void DeactivePanel()
    {
        base.DeactivePanel();
    }

    #endregion Methods
}
