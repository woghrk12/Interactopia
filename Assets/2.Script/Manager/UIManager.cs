using System;
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

    #region Static Methods

    public static UIBase GetUIBase(EUIBase idxUIBase) { return Instance.uiBaseList[(int)idxUIBase]; }
    public static void TurnOn(EUIBase uiBase, bool isTurnOffOther = true) => Instance.TurnOnUIBase((int)uiBase, isTurnOffOther);
    public static void TurnOff(bool isAll = true, EUIBase uiBase = EUIBase.NONE) => Instance.TurnOffUIBase(isAll, (int)uiBase);

    #endregion Static Methods

    #region Methods

    private void TurnOnUIBase(int idxUIBase, bool isTurnOffOther)
    {
        if (idxUIBase < 0 || idxUIBase >= uiBaseList.Length) { throw new Exception($"Out of range. Input idx : {idxUIBase}"); }

        uiBaseList[idxUIBase].gameObject.SetActive(true);

        if (!isTurnOffOther) { return; }

        for (int cnt = 0; cnt < uiBaseList.Length; cnt++)
        {
            if (cnt == idxUIBase) { continue; }

            uiBaseList[cnt].gameObject.SetActive(false);
        }
    }

    private void TurnOffUIBase(bool isAll, int idxUIBase)
    {
        if (isAll)
        {
            foreach (UIBase uiBase in uiBaseList) { uiBase.gameObject.SetActive(false); }

            return;
        }

        if (idxUIBase < 0 || idxUIBase >= uiBaseList.Length) { throw new Exception($"Out of range. Input idx : {idxUIBase}"); }

        uiBaseList[idxUIBase].gameObject.SetActive(false);
    }

    #endregion Methods
}
