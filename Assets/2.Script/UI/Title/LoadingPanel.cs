using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingPanel : UIPanel
{
    #region Variables

    private TitleUI titleUI = null;

    #endregion Variables
 
    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        titleUI = uiBase as TitleUI;
    }

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
