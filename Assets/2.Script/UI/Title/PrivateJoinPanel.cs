using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PrivateJoinPanel : UIPanel
{
    #region Variables

    private TitleUI titleUI = null;

    [SerializeField] private InputField roomCodeInputField = null;
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

    public void OnClickCloseBtn() => titleUI.TurnOffPanel(ETitleUIPanel.SETTING); 

    public void OnClickEnterBtn() => NetworkManager.JoinRoom(roomCodeInputField.text);

    #endregion Methods
}
