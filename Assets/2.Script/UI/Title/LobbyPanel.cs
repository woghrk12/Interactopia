using UnityEngine;
using UnityEngine.UI;

public class LobbyPanel : UIPanel
{
    #region Varibles

    private TitleUI titleUI = null;

    [SerializeField] private Button createRoomBtn = null;
    [SerializeField] private Button publicJoinBtn = null;
    [SerializeField] private Button privateJoinBtn = null;
    [SerializeField] private Button cancelBtn = null;

    #endregion Varibles

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        titleUI = uiBase as TitleUI;

        createRoomBtn.onClick.AddListener(() => titleUI.TurnOnPanel(ETitleUIPanel.CREATEROOM));
        publicJoinBtn.onClick.AddListener(() => titleUI.TurnOnPanel(ETitleUIPanel.PUBLICJOIN));
        privateJoinBtn.onClick.AddListener(() => titleUI.TurnOnPanel(ETitleUIPanel.PRIVATEJOIN));
        cancelBtn.onClick.AddListener(() => titleUI.TurnOnPanel(ETitleUIPanel.START));
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
