using UnityEngine;

public abstract class UIPanel : MonoBehaviour
{
    #region Variables

    private UIBase uiBase = null;

    [SerializeField] private bool isPopup = false;

    #endregion Variables

    #region Properties

    public UIBase UIBase => uiBase;

    public bool IsPopup => isPopup;

    #endregion Properties

    #region Methods

    public virtual void InitPanel(UIBase uiBase)
    {
        this.uiBase = uiBase;
    }

    public virtual void ActivatePanel() { if (!gameObject.activeSelf) gameObject.SetActive(true); }

    public virtual void DeactivePanel() { if (gameObject.activeSelf) gameObject.SetActive(false); }

    #endregion Methods
}
