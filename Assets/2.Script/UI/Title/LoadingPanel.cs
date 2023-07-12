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

    #endregion Methods

    #region Override Methods

    public override IEnumerator ActiveAnimation()
    {
        yield break;
    }

    public override IEnumerator DeactiveAnimation()
    {
        yield break;
    }

    #endregion Override Methods
}
