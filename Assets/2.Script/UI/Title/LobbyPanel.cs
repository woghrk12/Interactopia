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

    public void OnClickCreateRoomBtn() { StartCoroutine(titleUI.TurnOnPanel(ETitleUIPanel.CREATEROOM)); }

    public void OnClickPublicJoinBtn() { StartCoroutine(titleUI.TurnOnPanel(ETitleUIPanel.PUBLICJOIN)); }

    public void OnClickPrivateJoinBtn() { StartCoroutine(titleUI.TurnOnPanel(ETitleUIPanel.PRIVATEJOIN)); }

    public void OnClickCancelBtn() { StartCoroutine(titleUI.TurnOnPanel(ETitleUIPanel.START)); }

    public override IEnumerator ActivatePanel(bool isEffect)
    {
        if (!gameObject.activeSelf) { gameObject.SetActive(true); }

        if (isEffect)
        {
            // TODO : implement panel effects
            yield return null;
        }
    }

    public override IEnumerator DeactivePanel(bool isEffect)
    {
        if (isEffect)
        {
            // TODO : implement panel effects
            yield return null;
        }

        if (gameObject.activeSelf) { gameObject.SetActive(false); }
    }

    #endregion Methods
}
