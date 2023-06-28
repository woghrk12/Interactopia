using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateRoomPanel : UIPanel
{
    #region Variables

    private TitleUI titleUI = null;

    [SerializeField] private Button createBtn = null;
    [SerializeField] private Button cancelBtn = null;

    #endregion Variables
 
    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        titleUI = uiBase as TitleUI;

        createBtn.onClick.AddListener(OnClickCreateBtn);
        cancelBtn.onClick.AddListener(OnClickCancelBtn);
    }

    public void OnClickCreateBtn() { SceneManager.LoadScene(1); }

    public void OnClickCancelBtn() { StartCoroutine(titleUI.TurnOnPanel(ETitleUIPanel.LOBBY)); }

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
