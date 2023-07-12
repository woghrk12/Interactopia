using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.Collections;

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

    #region Event Methods

    public void OnClickCloseBtn() => titleUI.TurnOffPanel(ETitleUIPanel.PRIVATEJOIN);

    public void OnClickEnterBtn() => PhotonNetwork.JoinRoom(roomCodeInputField.text);

    #endregion Event Methods
}
