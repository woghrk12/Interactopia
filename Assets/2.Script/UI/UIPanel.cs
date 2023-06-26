using UnityEngine;

public abstract class UIPanel : MonoBehaviour
{
    #region Variables

    [SerializeField] private bool isPopup = false;

    #endregion Variables

    #region Methods

    public abstract void InitPanel();

    public abstract void ResetPanel();

    public abstract void ActivatePanel();

    public abstract void DeactivePanel();

    #endregion Methods
}
