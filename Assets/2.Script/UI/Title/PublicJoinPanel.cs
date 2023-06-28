using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PublicJoinPanel : UIPanel
{
    #region Variables

    private TitleUI titleUI = null;

    [SerializeField] private Button joinBtn = null;
    [SerializeField] private Button cancelBtn = null;

    #endregion Variables

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        titleUI = uiBase as TitleUI;

        joinBtn.onClick.AddListener(OnClickJoinBtn);
        cancelBtn.onClick.AddListener(OnClickCancelBtn);
    }

    public void OnClickJoinBtn() { SceneManager.LoadScene(1); }

    public void OnClickCancelBtn() { titleUI.TurnOnPanel(ETitleUIPanel.LOBBY); }

    public override IEnumerator OnActivePanel()
    {
        // TODO : implement panel effects
        yield return null;
    }

    public override IEnumerator OnDeactivePanel()
    {
        // TODO : implement panel effects
        yield return null;
    }

    #endregion Methods
}
