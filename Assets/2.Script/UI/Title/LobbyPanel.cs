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
        return DOTween.Sequence().Append(titleUI.FadeIn(0.5f));
    }

    public override Sequence DeactiveAnimation()
    {
        return DOTween.Sequence().Append(titleUI.FadeOut(0.5f));
    }

    #endregion Override Methods

    #region Event Methods

    public void OnClickCreateRoomBtn() => titleUI.OpenPanel(ETitleUIPanel.CREATEROOM, ETitleUIPanel.LOBBY); 

    public void OnClickPublicJoinBtn() => titleUI.OpenPanel(ETitleUIPanel.PUBLICJOIN, ETitleUIPanel.LOBBY); 

    public void OnClickPrivateJoinBtn() => titleUI.PopupPanel(ETitleUIPanel.PRIVATEJOIN);

    public void OnClickCancelBtn() => titleUI.OpenPanel(ETitleUIPanel.START, ETitleUIPanel.LOBBY);

    public void OnClickAuthBtn() => titleUI.PopupPanel(ETitleUIPanel.AUTH);

    #endregion Event Methods
}
