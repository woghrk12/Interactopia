using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class SettingPanel : UIPanel
{
    #region Variables

    private UIBase uiBase = null;

    [SerializeField] private Image backgroundImg = null;
    [SerializeField] private Button closeBtn = null;
    [SerializeField] private Button exitRoomBtn = null;
    [SerializeField] private Button exitGameBtn = null;

    #endregion Variables

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        this.uiBase = uiBase;

        if (SceneManager.GetActiveScene().buildIndex == 0) 
        {
            exitRoomBtn.gameObject.SetActive(false);

            backgroundImg.GetComponent<Button>().onClick.AddListener(OnClickCloseBtn);
            closeBtn.onClick.AddListener(OnClickCloseBtn);
        }
        else
        {
            exitRoomBtn.gameObject.SetActive(true);

            backgroundImg.GetComponent<Button>().onClick.AddListener(OnClickCloseBtn);
            closeBtn.onClick.AddListener(OnClickCloseBtn);
            exitRoomBtn.onClick.AddListener(OnClickExitRoomBtn);
        }

        exitGameBtn.onClick.AddListener(OnClickExitGameBtn);
    }

    public void OnClickCloseBtn() 
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) { ((TitleUI)uiBase).TurnOffPanel(ETitleUIPanel.SETTING); }
        else { ((InGameUI)uiBase).TurnOffPanel(EInGamePanel.SETTING); }
    }

    public void OnClickExitRoomBtn() { SceneManager.LoadScene(0); }

    public void OnClickExitGameBtn() 
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    #endregion Methods
}
