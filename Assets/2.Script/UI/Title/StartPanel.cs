using UnityEngine;
using UnityEngine.UI;

public class StartPanel : UIPanel
{
    #region Variables

    private Animator anim = null;

    private TitleUI titleUI = null;

    [SerializeField] private Image titleImg = null;
    [SerializeField] private Button startBtn = null;
    [SerializeField] private Button settingBtn = null;

    #endregion Variables

    #region Unity Methods

    private void Awake()
    {
        //anim = GetComponent<Animator>();
    }

    #endregion Unity Methods

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        titleUI = uiBase as TitleUI;

        startBtn.onClick.AddListener(() => titleUI.TurnOnPanel(ETitleUIPanel.LOBBY));
        settingBtn.onClick.AddListener(() => titleUI.TurnOnPanel(ETitleUIPanel.SETTING));
    }

    public override void ActivatePanel()
    {
        base.ActivatePanel();

        anim?.SetTrigger("On");
    }

    public override void DeactivePanel()
    {
        base.DeactivePanel();
    }

    #endregion Methods
}
