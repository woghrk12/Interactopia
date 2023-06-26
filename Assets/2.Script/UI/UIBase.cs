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

    #endregion Unity Events

    #region Methods

    public virtual void Init()
    {
        foreach (UIPanel uiPanel in uiPanelList)
        {
            uiPanel.InitPanel();
            uiPanel.gameObject.SetActive(false);
        }
    }

    public virtual void TurnOnUIPanel(int idxUIPanel)
    { 
        if (idxUIPanel < 0 || idxUIPanel >= uiPanelList.Length) { throw new Exception($"Out of range. Input idx : {idxUIPanel}"); }

        uiPanelList[idxUIPanel].gameObject.SetActive(true);
        uiPanelList[idxUIPanel].OnActive?.Invoke();
    }

    public virtual void TurnOffUIPanel(int idxUIPanel)
    {
        if (idxUIPanel < 0 || idxUIPanel >= uiPanelList.Length) { throw new Exception($"Out of range. Input idx : {idxUIPanel}"); }

        uiPanelList[idxUIPanel].OnDeactive?.Invoke();
        uiPanelList[idxUIPanel].gameObject.SetActive(false);
    }

    #endregion Methods
}
