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

    public virtual void ActivatePanel() { if (!gameObject.activeSelf) gameObject.SetActive(true); }

    public virtual void DeactivePanel() { if (gameObject.activeSelf) gameObject.SetActive(false); }

    #endregion Methods
}
