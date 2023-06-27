using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PublicJoinPanel : UIPanel
{
    #region Variables

    private TitleUI titleUI = null;

    [SerializeField] private Button joinBtn = null;
    [SerializeField] private Button cancelBtn = null;

    #endregion Variables

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        titleUI = uiBase as TitleUI;

        joinBtn.onClick.AddListener(() => SceneManager.LoadScene(1));
        cancelBtn.onClick.AddListener(() => titleUI.TurnOnPanel(ETitleUIPanel.LOBBY));
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
