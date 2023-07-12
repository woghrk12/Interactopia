using System;
using UnityEngine;
using Photon.Pun;

public abstract class UIPanel : MonoBehaviourPunCallbacks
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
