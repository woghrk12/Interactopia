using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using DG.Tweening;

public class AuthPanel : UIPanel
{
    #region Varibles

    private TitleUI titleUI = null;

    [SerializeField] private Image backgroundImg = null;
    [SerializeField] private RectTransform infoPanelRect = null;
    [SerializeField] private Button setNicknameBtn = null;
    [SerializeField] private Text nicknameValueText = null;

    [SerializeField] private GameObject setNicknameBackgroundImg = null;
    [SerializeField] private RectTransform setNicknamePanelRect = null;
    [SerializeField] private GameObject setNicknamePanel = null;
    [SerializeField] private InputField nicknameInputfield = null;
    [SerializeField] private Button cancelBtn = null;
    [SerializeField] private Button confirmBtn = null;

    #endregion Varibles

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        titleUI = uiBase as TitleUI;

        nicknameValueText.text = PhotonNetwork.LocalPlayer.NickName;

        backgroundImg.GetComponent<Button>().onClick.AddListener(OnClickCloseBtn);
        setNicknameBtn.onClick.AddListener(OnClickSetNicknameBtn);
        cancelBtn.onClick.AddListener(OnClickCancelBtn);
        confirmBtn.onClick.AddListener(OnClickConfirmBtn);

        nicknameInputfield.onEndEdit.AddListener(OnNicknameEndEdit);

        infoPanelRect.anchoredPosition = new Vector2(-infoPanelRect.sizeDelta.x, infoPanelRect.anchoredPosition.y);
        setNicknamePanelRect.localScale = Vector3.zero;

        setNicknamePanel.SetActive(false);
        setNicknameBackgroundImg.SetActive(false);
    }

    #endregion Methods

    #region Override Methods

    public override Sequence ActiveAnimation()
    {
        Tween panelTween = infoPanelRect.DOAnchorPosX(0f, 0.5f)
            .SetEase(Ease.OutExpo);

        return DOTween.Sequence().Append(panelTween);
    }

    public override Sequence DeactiveAnimation()
    {
        Tween panelTween = infoPanelRect.DOAnchorPosX(-infoPanelRect.sizeDelta.x, 0.5f)
            .SetEase(Ease.InExpo);

        return DOTween.Sequence().Append(panelTween);
    }

    #endregion Override Methods

    #region Event Methods

    public void OnClickCloseBtn() => titleUI.ClosePanel(ETitleUIPanel.AUTH);

    public void OnClickSetNicknameBtn()
    {
        Tween panelTween = setNicknamePanelRect.DOScale(1f, 0.5f)
            .SetEase(Ease.OutExpo)
            .OnStart(() =>
                {
                    setNicknameBackgroundImg.SetActive(true);
                    setNicknamePanel.SetActive(true);
                })
            .Play();
    }

    public void OnClickCancelBtn()
    {
        Tween panelTween = setNicknamePanelRect.DOScale(0f, 0.5f)
            .SetEase(Ease.OutExpo)
            .OnComplete(() =>
                {
                    setNicknameBackgroundImg.SetActive(false);
                    setNicknamePanel.SetActive(false);
                })
            .Play();
    }

    public void OnClickConfirmBtn()
    {
        PhotonNetwork.LocalPlayer.NickName = nicknameValueText.text = nicknameInputfield.text;
        setNicknamePanel.SetActive(false);
    }

    public void OnNicknameEndEdit(string value) => nicknameInputfield.text = value.Substring(0, 10);
    

    #endregion Event Methods
}
