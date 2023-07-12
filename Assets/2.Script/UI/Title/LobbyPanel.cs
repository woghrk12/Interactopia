using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LobbyPanel : UIPanel
{
    #region Varibles

    private TitleUI titleUI = null;

    [SerializeField] private Button createRoomBtn = null;
    [SerializeField] private Button publicJoinBtn = null;
    [SerializeField] private Button privateJoinBtn = null;
    [SerializeField] private Button cancelBtn = null;
    [SerializeField] private Button authBtn = null;

    #endregion Varibles

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        titleUI = uiBase as TitleUI;

        createRoomBtn.onClick.AddListener(OnClickCreateRoomBtn);
        publicJoinBtn.onClick.AddListener(OnClickPublicJoinBtn);
        privateJoinBtn.onClick.AddListener(OnClickPrivateJoinBtn);
        cancelBtn.onClick.AddListener(OnClickCancelBtn);
        authBtn.onClick.AddListener(OnClickAuthBtn);
    }

    #endregion Methods

    #region Override Methods

    public override Sequence ActiveAnimation()
    {
        return DOTween.Sequence();
    }

    public override Sequence DeactiveAnimation()
    {
        return DOTween.Sequence();
    }

    #endregion Override Methods

    #region Event Methods

    public void OnClickCreateRoomBtn() => titleUI.TurnOnPanel(ETitleUIPanel.CREATEROOM); 

    public void OnClickPublicJoinBtn() => titleUI.TurnOnPanel(ETitleUIPanel.PUBLICJOIN); 

    public void OnClickPrivateJoinBtn() => titleUI.TurnOnPanel(ETitleUIPanel.PRIVATEJOIN);

    public void OnClickCancelBtn() => titleUI.TurnOnPanel(ETitleUIPanel.START);

    public void OnClickAuthBtn() => titleUI.TurnOnPanel(ETitleUIPanel.AUTH);

    #endregion Event Methods
}
