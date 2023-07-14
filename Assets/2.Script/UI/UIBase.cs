using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public abstract class UIBase : MonoBehaviour
{
    #region Variables

    public static UIBase Instance = null;

    protected UIPanel[] uiPanelList = new UIPanel[0];

    private Action yesBtnClicked = null;
    private Action noBtnClicked = null;

    [SerializeField] private GameObject alertPanel = null;
    [SerializeField] private Text alertText = null;
    [SerializeField] private Button yesBtn = null;
    [SerializeField] private Button noBtn = null;
    [SerializeField] private Image fadeImg = null;

    #endregion Variables

    #region Unity Events

    protected virtual void Awake()
    {
        Instance = this;

        uiPanelList = transform.GetComponentsInChildren<UIPanel>(true);
    }

    #endregion Unity Events

    #region Methods

    public virtual void InitBase()
    {
        yesBtn.onClick.AddListener(OnClickYesBtn);
        noBtn.onClick.AddListener(OnClickNoBtn);

        foreach (UIPanel panel in uiPanelList)
        {
            panel.InitPanel(this);
            if (panel.gameObject.activeSelf) { panel.gameObject.SetActive(false); }
        }
    }

    protected void OpenPanel(int openIdx, int closeIdx)
    {
        if (openIdx < 0 || openIdx >= uiPanelList.Length) { throw new Exception($"Out of range. Input idx : {openIdx}"); }
        if (closeIdx < 0 || closeIdx >= uiPanelList.Length) { throw new Exception($"Out of range. Input idx : {closeIdx}"); }

        if (uiPanelList[openIdx].gameObject.activeSelf) { return; }

        Sequence sequence = DOTween.Sequence();

        Sequence deactiveAnim = uiPanelList[closeIdx].DeactiveAnimation();
        deactiveAnim.OnComplete(() =>
        {
            uiPanelList[closeIdx].OnDeactive?.Invoke();
            uiPanelList[closeIdx].gameObject.SetActive(false);
        });
        sequence.Append(deactiveAnim);

        Sequence activeAnim = uiPanelList[openIdx].ActiveAnimation();
        activeAnim.OnStart(() =>
        {
            uiPanelList[openIdx].gameObject.SetActive(true);
            uiPanelList[openIdx].OnActive?.Invoke();
        });
        sequence.Append(activeAnim);

        sequence.Play();
    }

    protected void ClosePanel(int closeIdx)
    {
        if (closeIdx < 0 || closeIdx >= uiPanelList.Length) { throw new Exception($"Out of range. Input idx : {closeIdx}"); }
        if (!uiPanelList[closeIdx].gameObject.activeSelf) { return; }

        uiPanelList[closeIdx].DeactiveAnimation()
            .OnComplete(() =>
                {
                    uiPanelList[closeIdx].OnDeactive?.Invoke();
                    uiPanelList[closeIdx].gameObject.SetActive(false);
                })
            .Play();
    }

    protected void PopupPanel(int popupIdx)
    {
        if (popupIdx < 0 || popupIdx >= uiPanelList.Length) { throw new Exception($"Out of range. Input idx : {popupIdx}"); }
        if (uiPanelList[popupIdx].gameObject.activeSelf) { return; }

        uiPanelList[popupIdx].ActiveAnimation()
            .OnStart(() =>
                {
                    Debug.Log("Popup Panel");
                    uiPanelList[popupIdx].gameObject.SetActive(true);
                    uiPanelList[popupIdx].OnActive?.Invoke();
                })
            .Play();
    }

    public void Alert(string message, Action yesEvent = null, Action noEvent = null)
    {
        alertPanel.gameObject.SetActive(true);

        alertText.text = message;
        if (yesEvent != null) { yesBtnClicked += yesEvent; }

        if (noEvent != null)
        {
            noBtnClicked += noEvent;
            noBtn.gameObject.SetActive(true);
        }
        else
        {
            noBtn.gameObject.SetActive(false);
        }
    }

    public Tween FadeIn(float duration)
    {
        return fadeImg.DOColor(new Color(0f, 0f, 0f, 0f), duration)
            .OnStart(() => fadeImg.color = new Color(0f, 0f, 0f, 1f))
            .OnComplete(() => fadeImg.gameObject.SetActive(false));
    }

    public Tween FadeOut(float duration)
    {
        return fadeImg.DOColor(new Color(0f, 0f, 0f, 1f), duration)
            .OnStart(() =>
                {
                    fadeImg.gameObject.SetActive(true);
                    fadeImg.color = new Color(0f, 0f, 0f, 0f);
                });
    }

    public void OnClickYesBtn()
    {
        yesBtnClicked?.Invoke();

        yesBtnClicked = null;
        noBtnClicked = null;

        alertPanel.gameObject.SetActive(false);
    }

    public void OnClickNoBtn()
    {
        noBtnClicked?.Invoke();

        yesBtnClicked = null;
        noBtnClicked = null;

        alertPanel.gameObject.SetActive(false);
    }

    #endregion Event Methods
}
