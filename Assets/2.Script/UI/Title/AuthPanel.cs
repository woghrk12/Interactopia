using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.Collections;

public class AuthPanel : UIPanel
{
    #region Varibles

    private TitleUI titleUI = null;

    [SerializeField] private Image backgroundImg = null;
    [SerializeField] private Button closeBtn = null;
    [SerializeField] private Button setNicknameBtn = null;
    [SerializeField] private Text nicknameValueText = null;

    [SerializeField] private GameObject setNicknamePanel = null;
    [SerializeField] private InputField nicknameInputfield = null;
    [SerializeField] private Button cancelBtn = null;
    [SerializeField] private Button confirmBtn = null;

    #endregion Varibles

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        titleUI = uiBase as TitleUI;

        backgroundImg.GetComponent<Button>().onClick.AddListener(OnClickCloseBtn);
        closeBtn.onClick.AddListener(OnClickCloseBtn);
        setNicknameBtn.onClick.AddListener(OnClickSetNicknameBtn);
        cancelBtn.onClick.AddListener(OnClickCancelBtn);
        confirmBtn.onClick.AddListener(OnClickConfirmBtn);

        nicknameInputfield.onEndEdit.AddListener(OnNicknameEndEdit);

        OnActive += (() => 
        {
            nicknameValueText.text = PhotonNetwork.LocalPlayer.NickName;
            if (setNicknamePanel.activeSelf) setNicknamePanel.SetActive(false); 
        });
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

    public void OnClickCloseBtn() => titleUI.TurnOffPanel(ETitleUIPanel.AUTH);

    public void OnClickSetNicknameBtn() => setNicknamePanel.SetActive(true);

    public void OnClickCancelBtn() => setNicknamePanel.SetActive(false);

    public void OnClickConfirmBtn()
    {
        PhotonNetwork.LocalPlayer.NickName = nicknameValueText.text = nicknameInputfield.text;
        setNicknamePanel.SetActive(false);
    }

    public void OnNicknameEndEdit(string value) => nicknameInputfield.text = value.Substring(0, 10);
    

    #endregion Event Methods
}
