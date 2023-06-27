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
            backgroundImg.GetComponent<Button>().onClick.AddListener(() => titleUI.TurnOffPanel(ETitleUIPanel.SETTING));
            closeBtn.onClick.AddListener(() => titleUI.TurnOffPanel(ETitleUIPanel.SETTING));
            exitRoomBtn.gameObject.SetActive(false);
        }
        else
        { 
            
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
