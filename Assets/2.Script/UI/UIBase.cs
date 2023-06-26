using System;
using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    #region Variables

    private UIPanel[] uiPanelList = new UIPanel[0];

    #endregion Variables

    #region Unity Events

    protected virtual void Awake()
    {
        uiPanelList = transform.GetComponentsInChildren<UIPanel>();
    }

    #endregion Unity Events

    #region Methods

    public virtual void Init()
    {
        foreach (UIPanel uiPanel in uiPanelList)
        {
            // TODO : Initialize each panel
            uiPanel.gameObject.SetActive(false);
        }
    }

    public virtual void TurnOnUIPanel(int idxUIPanel)
    { 
        if (idxUIPanel < 0 || idxUIPanel >= uiPanelList.Length) { throw new Exception($"Out of range. Input idx : {idxUIPanel}"); }

        uiPanelList[idxUIPanel].gameObject.SetActive(true);
    }

    public virtual void TurnOffUIPanel(int idxUIPanel)
    {
        if (idxUIPanel < 0 || idxUIPanel >= uiPanelList.Length) { throw new Exception($"Out of range. Input idx : {idxUIPanel}"); }

        uiPanelList[idxUIPanel].gameObject.SetActive(false);
    }

    #endregion Methods
}
