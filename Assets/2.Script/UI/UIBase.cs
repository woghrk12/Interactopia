using System;
using System.Collections;
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
        uiPanelList = transform.GetComponentsInChildren<UIPanel>(true);
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

    protected virtual IEnumerator TurnOnUIPanel(int idx, bool hasOnEffect, bool hasOffEffect)
    { 
        if (idx < 0 || idx >= uiPanelList.Length) { throw new Exception($"Out of range. Input idx : {idx}"); }

        if (!uiPanelList[idx].IsPopup && curPanel >= 0)
        {
            uiPanelList[curPanel].gameObject.SetActive(false);
            if (hasOffEffect) { yield return uiPanelList[curPanel].OnDeactivePanel(); }
        }

        uiPanelList[idx].gameObject.SetActive(true);
        if (hasOnEffect) { yield return uiPanelList[idx].OnActivePanel(); }

        curPanel = idx;
    }

    protected virtual IEnumerator TurnOffUIPanel(int idxUIPanel, bool hasOffEffect)
    {
        if (idxUIPanel < 0 || idxUIPanel >= uiPanelList.Length) { throw new Exception($"Out of range. Input idx : {idxUIPanel}"); }

        uiPanelList[idxUIPanel].gameObject.SetActive(false);
        if (hasOffEffect) { yield return uiPanelList[idxUIPanel].OnDeactivePanel(); }
    }

    #endregion Methods
}
