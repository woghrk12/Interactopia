using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartPanel : UIPanel
{
    #region Variables

    private TitleUI titleUI = null;

    [SerializeField] private Image titleImg = null;
    [SerializeField] private Button startBtn = null;
    [SerializeField] private Button howToPlayBtn = null;
    [SerializeField] private Button settingBtn = null;
    [SerializeField] private Button creditBtn = null;
    [SerializeField] private Button noticeBtn = null;
    [SerializeField] private Button authBtn = null;

    #endregion Variables

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        titleUI = uiBase as TitleUI;

        startBtn.onClick.AddListener(OnClickStartBtn);
        settingBtn.onClick.AddListener(OnClickSettingBtn);
        authBtn.onClick.AddListener(OnClickAuthBtn);
    }

    #endregion Methods

    #region Override Methods

    public override Sequence ActiveAnimation()
    {
        RectTransform titleImgRect = titleImg.GetComponent<RectTransform>();
        Tween titleImgTween = DoTweenUtil.DoAnchoredPos(
            titleImgRect,
            titleImgRect.anchoredPosition + new Vector2(0f, 800f),
            titleImgRect.anchoredPosition,
            1f,
            Ease.OutBounce);

        RectTransform startBtnRect = startBtn.GetComponent<RectTransform>();
        Tween startBtnTween = DoTweenUtil.DoAnchoredPos(
            startBtnRect,
            startBtnRect.anchoredPosition + new Vector2(0f, -1200f),
            startBtnRect.anchoredPosition,
            0.5f,
            Ease.OutExpo);

        RectTransform howToPlayBtnRect = howToPlayBtn.GetComponent<RectTransform>();
        Tween howToPlayBtnTween = DoTweenUtil.DoAnchoredPos(
            howToPlayBtnRect,
            howToPlayBtnRect.anchoredPosition + new Vector2(0f, -1200f),
            howToPlayBtnRect.anchoredPosition,
            0.5f,
            Ease.OutExpo);

        RectTransform settingBtnRect = settingBtn.GetComponent<RectTransform>();
        Tween settingBtnTween = DoTweenUtil.DoAnchoredPos(
            settingBtnRect,
            settingBtnRect.anchoredPosition + new Vector2(0f, -1200f),
            settingBtnRect.anchoredPosition,
            0.5f,
            Ease.OutExpo);

        RectTransform creditBtnRect = creditBtn.GetComponent<RectTransform>();
        Tween creditBtnTween = DoTweenUtil.DoAnchoredPos(
            creditBtnRect,
            creditBtnRect.anchoredPosition + new Vector2(0f, -1200f),
            creditBtnRect.anchoredPosition,
            0.5f,
            Ease.OutExpo);

        RectTransform noticeBtnRect = noticeBtn.GetComponent<RectTransform>();
        Tween noticeBtnTween = DoTweenUtil.DoAnchoredPos(
            noticeBtnRect,
            noticeBtnRect.anchoredPosition + new Vector2(0f, -1200f),
            noticeBtnRect.anchoredPosition,
            0.5f,
            Ease.OutExpo);

        return DOTween.Sequence()
            .Append(titleUI.FadeIn(0.5f))
            .Append(titleImgTween)
            .Append(startBtnTween)
            .Append(howToPlayBtnTween)
            .Append(settingBtnTween).Join(creditBtnTween).Join(noticeBtnTween);
    }

    public override Sequence DeactiveAnimation()
    {
        return DOTween.Sequence().Append(titleUI.FadeOut(0.5f));
    }

    #endregion Override Methods

    #region Event Methods

    public void OnClickStartBtn() => titleUI.OpenPanel(ETitleUIPanel.LOBBY, ETitleUIPanel.START);

    public void OnClickSettingBtn() => titleUI.PopupPanel(ETitleUIPanel.SETTING); 

    public void OnClickAuthBtn() => titleUI.PopupPanel(ETitleUIPanel.AUTH);

    #endregion Event Methods
}
