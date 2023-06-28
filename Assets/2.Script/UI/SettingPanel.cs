using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingPanel : UIPanel
{
    #region Variables

    private UIBase uiBase = null;

    [SerializeField] private Image backgroundImg = null;
    [SerializeField] private Button closeBtn = null;
    [SerializeField] private Button exitRoomBtn = null;
    [SerializeField] private Button exitGameBtn = null;

    #endregion Variables

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        this.uiBase = uiBase;

        if (SceneManager.GetActiveScene().buildIndex == 0) 
        {
            TitleUI titleUI = this.uiBase as TitleUI;

            exitRoomBtn.gameObject.SetActive(false);
            
            backgroundImg.GetComponent<Button>().onClick.AddListener(() => titleUI.TurnOffPanel(ETitleUIPanel.SETTING));
            closeBtn.onClick.AddListener(() => titleUI.TurnOffPanel(ETitleUIPanel.SETTING));
        }
        else
        {
            InGameUI inGameUI = this.uiBase as InGameUI;

            exitRoomBtn.gameObject.SetActive(true);

            backgroundImg.GetComponent<Button>().onClick.AddListener(() => inGameUI.TurnOffPanel(EInGamePanel.SETTING));
            closeBtn.onClick.AddListener(() => inGameUI.TurnOffPanel(EInGamePanel.SETTING));
            exitRoomBtn.onClick.AddListener(() => SceneManager.LoadScene(0));
        }

        exitGameBtn.onClick.AddListener(() => Application.Quit());
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
