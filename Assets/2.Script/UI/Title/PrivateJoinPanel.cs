using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrivateJoinPanel : UIPanel
{
    #region Variables

    private TitleUI titleUI = null;

    [SerializeField] private Image backgroundImg = null;
    [SerializeField] private Button closeBtn = null;
    [SerializeField] private Button enterBtn = null;

    #endregion Variables

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        titleUI = uiBase as TitleUI;

        backgroundImg.GetComponent<Button>().onClick.AddListener(OnClickCloseBtn);
        closeBtn.onClick.AddListener(OnClickCloseBtn);
        enterBtn.onClick.AddListener(OnClickEnterBtn);
    }

    public void OnClickCloseBtn() { StartCoroutine(titleUI.TurnOffPanel(ETitleUIPanel.SETTING)); }

    public void OnClickEnterBtn() { SceneManager.LoadScene(1); }

    public override IEnumerator ActivatePanel(bool isEffect)
    {
        if (!gameObject.activeSelf) { gameObject.SetActive(true); }

        if (isEffect)
        {
            // TODO : implement panel effects
            yield return null;
        }
    }

    public override IEnumerator DeactivePanel(bool isEffect)
    {
        if (isEffect)
        {
            // TODO : implement panel effects
            yield return null;
        }

        if (gameObject.activeSelf) { gameObject.SetActive(false); }
    }

    #endregion Methods
}
