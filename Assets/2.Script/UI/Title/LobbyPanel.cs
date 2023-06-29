using System.Collections;
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

        createRoomBtn.onClick.AddListener(OnClickCreateRoomBtn);
        publicJoinBtn.onClick.AddListener(OnClickPublicJoinBtn);
        privateJoinBtn.onClick.AddListener(OnClickPrivateJoinBtn);
        cancelBtn.onClick.AddListener(OnClickCancelBtn);
    }

    public void OnClickCreateRoomBtn() { titleUI.TurnOnPanel(ETitleUIPanel.CREATEROOM); }

    public void OnClickPublicJoinBtn() { titleUI.TurnOnPanel(ETitleUIPanel.PUBLICJOIN); }

    public void OnClickPrivateJoinBtn() { titleUI.TurnOnPanel(ETitleUIPanel.PRIVATEJOIN); }

    public void OnClickCancelBtn() { titleUI.TurnOnPanel(ETitleUIPanel.START); }

    public override IEnumerator OnActivePanel()
    {
        // TODO : implement panel effects
        yield return null;
    }

    public override IEnumerator OnDeactivePanel()
    {
        // TODO : implement panel effects
        yield return null;
    }

    #endregion Methods
}
