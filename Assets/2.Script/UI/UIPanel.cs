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
    
    public Action OnActive { protected set; get; }

    public Action OnDeactive { protected set; get; }

    #endregion Properties

    #region Methods

    public abstract void InitPanel(UIBase uiBase);

    #endregion Methods
}
