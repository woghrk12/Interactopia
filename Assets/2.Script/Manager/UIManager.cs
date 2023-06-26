using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EUIBase { NONE = -1, TITLE, INGAME, SETTING, END  }

public class UIManager : SingletonMonobehaviour<UIManager>
{
    #region Variables

    [SerializeField] private UIBase[] uiBaseList = new UIBase[0];

    #endregion Variables

    #region Unity Events

    protected override void Awake()
    {
        base.Awake();

        uiBaseList = transform.GetComponentsInChildren<UIBase>();
    }

    #endregion Unity Events

    #region Methods

    public UIBase GetUIBase(EUIBase idxUIBase) { return this.uiBaseList[(int)idxUIBase]; }

    public void TurnOnUIBase(EUIBase idxUIBase, bool isTurnOffOther = true)
    {
        uiBaseList[(int)idxUIBase].gameObject.SetActive(true);

        if (!isTurnOffOther) { return; }

        for (EUIBase idx = EUIBase.TITLE; idx < EUIBase.END; idx++)
        {
            if (idx == idxUIBase) { continue; }

            uiBaseList[(int)idxUIBase].gameObject.SetActive(false);
        }
    }

    public void TurnOffUIBase(bool isAll = true, EUIBase idxUIBase = EUIBase.NONE)
    {
        if (isAll)
        {
            foreach (UIBase uiBase in uiBaseList) { uiBase.gameObject.SetActive(false); }

            return;
        }

        uiBaseList[(int)idxUIBase].gameObject.SetActive(false);
    }

    #endregion Methods
}
