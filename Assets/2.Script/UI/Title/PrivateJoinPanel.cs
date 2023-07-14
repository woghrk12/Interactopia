using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using DG.Tweening;

public class PrivateJoinPanel : UIPanel
{
    #region Variables

    private TitleUI titleUI = null;

    [SerializeField] private InputField roomCodeInputField = null;
    [SerializeField] private RectTransform panelRect = null;
    [SerializeField] private Button backgroundButton = null;
    [SerializeField] private Button closeBtn = null;
    [SerializeField] private Button enterBtn = null;

    #endregion Variables

    #region Override Methods

    public override void InitPanel(UIBase uiBase)
    {
        titleUI = uiBase as TitleUI;

        backgroundButton.onClick.AddListener(OnClickCloseBtn);
        closeBtn.onClick.AddListener(OnClickCloseBtn);
        enterBtn.onClick.AddListener(OnClickEnterBtn);

        OnActive += () => roomCodeInputField.text = string.Empty;

        panelRect.localScale = Vector3.zero;

        SetInteratable(false);
    }

    public override Sequence ActiveAnimation()
    {
        Tween panelTween = panelRect.DOScale(1f, 0.5f)
            .SetEase(Ease.OutExpo)
            .OnStart(() => SetInteratable(false))
            .OnComplete(() => SetInteratable(true));

        return DOTween.Sequence().Append(panelTween);
    }

    public override Sequence DeactiveAnimation()
    {
        Tween panelTween = panelRect.DOScale(0f, 0.5f)
            .SetEase(Ease.OutExpo)
            .OnStart(() => SetInteratable(false));

        return DOTween.Sequence().Append(panelTween);
    }

    #endregion Override Methods

    #region Methods

    private void SetInteratable(bool isInteractable)
    {
        roomCodeInputField.interactable = isInteractable;
        backgroundButton.interactable = isInteractable;
        closeBtn.interactable = isInteractable;
        enterBtn.interactable = isInteractable;
    }

    #endregion Methods

    #region Event Methods

    public void OnClickCloseBtn() => titleUI.ClosePanel(ETitleUIPanel.PRIVATEJOIN);

    public void OnClickEnterBtn()
    {
        if (roomCodeInputField.text == string.Empty)
        {
            titleUI.Alert("Room code cannot be empty!!");
            return;
        }
        PhotonNetwork.JoinRoom(roomCodeInputField.text);
    }

    #endregion Event Methods
}
