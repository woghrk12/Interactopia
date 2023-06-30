using System;
using System.Collections;
using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    #region Variables

    public static UIBase Instance = null;

    protected int curPanel = -1;
    protected UIPanel[] uiPanelList = new UIPanel[0];

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
        foreach (UIPanel panel in uiPanelList)
        {
            panel.InitPanel(this);
            panel.gameObject.SetActive(false);
        }
    }

    protected virtual void TurnOnUIPanel(int idx)
    {
        if (idx < 0 || idx >= uiPanelList.Length) { throw new Exception($"Out of range. Input idx : {idx}"); }

        if (!uiPanelList[idx].IsPopup && curPanel >= 0) { uiPanelList[curPanel].gameObject.SetActive(false); }

        uiPanelList[idx].gameObject.SetActive(true);
        curPanel = idx;
    }

    protected virtual void TurnOffUIPanel(int idxUIPanel)
    {
        if (idxUIPanel < 0 || idxUIPanel >= uiPanelList.Length) { throw new Exception($"Out of range. Input idx : {idxUIPanel}"); }

        uiPanelList[idxUIPanel].gameObject.SetActive(false);
    }

    #endregion Methods
}
