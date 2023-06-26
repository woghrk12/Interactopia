using System;
using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    #region Variables

    protected int curPanel = -1;
    protected UIPanel[] uiPanelList = new UIPanel[0];

    #endregion Variables

    #region Unity Events

    protected virtual void Awake()
    {
        uiPanelList = transform.GetComponentsInChildren<UIPanel>();
    }

    protected virtual void Start()
    {
        foreach (UIPanel panel in uiPanelList)
        {
            if (!panel.gameObject.activeSelf) { panel.gameObject.SetActive(true); }

            panel.InitPanel(this);
            panel.gameObject.SetActive(false);
        }
    }

    #endregion Unity Events

    #region Methods

    public virtual void TurnOnUIPanel(int idx)
    { 
        if (idx < 0 || idx >= uiPanelList.Length) { throw new Exception($"Out of range. Input idx : {idx}"); }

        uiPanelList[idx].ActivatePanel();

        if (uiPanelList[idx].IsPopup) { return; }

        uiPanelList[curPanel].DeactivePanel();
        curPanel = idx;
    }

    public virtual void TurnOffUIPanel(int idxUIPanel)
    {
        if (idxUIPanel < 0 || idxUIPanel >= uiPanelList.Length) { throw new Exception($"Out of range. Input idx : {idxUIPanel}"); }

        uiPanelList[idxUIPanel].DeactivePanel();
    }

    #endregion Methods
}
