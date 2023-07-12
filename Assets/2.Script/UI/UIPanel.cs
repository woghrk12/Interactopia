using System;
using System.Collections;
using UnityEngine;
using Photon.Pun;
using DG.Tweening;

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

    public abstract Sequence ActiveAnimation();

    public abstract Sequence DeactiveAnimation();

    #endregion Methods
}
