using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public abstract class UIBase : MonoBehaviour
{
    #region Variables

    public static UIBase Instance = null;

    protected int curPanel = -1;
    protected UIPanel[] uiPanelList = new UIPanel[0];

    private Action yesBtnClicked = null;
    private Action noBtnClicked = null;

    [SerializeField] private GameObject alertPanel = null;
    [SerializeField] private Text alertText = null;
    [SerializeField] private Button yesBtn = null;
    [SerializeField] private Button noBtn = null;

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

    protected virtual void TurnOnUIPanel(int idxUIPanel)
    {
        if (idxUIPanel < 0 || idxUIPanel >= uiPanelList.Length) { throw new Exception($"Out of range. Input idx : {idxUIPanel}"); }
        if (uiPanelList[idxUIPanel].gameObject.activeSelf) { return; }

        int openPanel = idxUIPanel;
        int closePanel = curPanel;

        Sequence activeTween = uiPanelList[openPanel].ActiveAnimation();
        activeTween.OnStart(() =>
        {
            uiPanelList[openPanel].gameObject.SetActive(true);
            uiPanelList[openPanel].OnActive?.Invoke();
        });

        if (curPanel < 0)
        {
            curPanel = openPanel;
            activeTween.Play();
            return;
        }

        Sequence sequence = DOTween.Sequence();

        if (!uiPanelList[openPanel].IsPopup)
        {
            Sequence deactiveTween = uiPanelList[closePanel].DeactiveAnimation();
            deactiveTween.OnComplete(() =>
            {
                uiPanelList[closePanel].OnDeactive?.Invoke();
                uiPanelList[closePanel].gameObject.SetActive(false);
            });
            sequence.Append(deactiveTween);

            curPanel = openPanel;
        }

        sequence.Append(activeTween);
        sequence.Play();
    }

    protected virtual void TurnOffUIPanel(int idxUIPanel)
    {
        if (idxUIPanel < 0 || idxUIPanel >= uiPanelList.Length) { throw new Exception($"Out of range. Input idx : {idxUIPanel}"); }
        if (!uiPanelList[idxUIPanel].gameObject.activeSelf) { return; }

        Sequence sequence = uiPanelList[idxUIPanel].DeactiveAnimation();
        sequence.OnComplete(() =>
        {
            uiPanelList[idxUIPanel].OnDeactive?.Invoke();
            uiPanelList[idxUIPanel].gameObject.SetActive(false);
        });

        sequence.Play();
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
