using System;
using UnityEngine;

public abstract class UIPanel : MonoBehaviour
{
    #region Variables

    public Action OnActive = null;
    public Action OnDeactive = null;

    #endregion Variables

    #region Methods

    public virtual void InitPanel() { }

    public virtual void ResetPanel() { }

    #endregion Methods
}
