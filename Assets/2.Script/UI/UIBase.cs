using System;
using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    #region Variables

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
            panel.InitPanel();
            panel.gameObject.SetActive(false);
        }
    }

    #endregion Unity Events

    #region Methods

    public virtual void TurnOnUIPanel(int idxUIPanel)
    { 
        if (idxUIPanel < 0 || idxUIPanel >= uiPanelList.Length) { throw new Exception($"Out of range. Input idx : {idxUIPanel}"); }

        uiPanelList[idxUIPanel].ActivatePanel();
    }

    public virtual void TurnOffUIPanel(int idxUIPanel)
    {
        if (idxUIPanel < 0 || idxUIPanel >= uiPanelList.Length) { throw new Exception($"Out of range. Input idx : {idxUIPanel}"); }

        uiPanelList[idxUIPanel].DeactivePanel();
    }

    #endregion Methods
}
