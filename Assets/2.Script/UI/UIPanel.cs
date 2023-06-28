using System;
using System.Collections;
using UnityEngine;

public abstract class UIPanel : MonoBehaviour
{
    #region Variables

    [SerializeField] private bool isPopup = false;

    #endregion Variables

    #region Properties

    public bool IsPopup => isPopup;

    #endregion Properties

    #region Methods

    public abstract void InitPanel(UIBase uiBase);

    public abstract IEnumerator OnActivePanel();

    public abstract IEnumerator OnDeactivePanel();

    #endregion Methods
}
