using UnityEngine;
using UnityEngine.UI;

public class StartPanel : UIPanel
{
    #region Variables

    private Animator anim = null;

    [SerializeField] private Image titleImg = null;
    [SerializeField] private Button startBtn = null;

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
        base.InitPanel(uiBase);

        startBtn.onClick.AddListener(() => UIBase.TurnOnUIPanel((int)ETitleUIPanel.LOBBY));
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
