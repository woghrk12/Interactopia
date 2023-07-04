using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class LobbyPanel : UIPanel
{
    #region Varibles

    private TitleUI titleUI = null;

    [SerializeField] private InputField nicknameInputField = null;
    [SerializeField] private Button createRoomBtn = null;
    [SerializeField] private Button publicJoinBtn = null;
    [SerializeField] private Button privateJoinBtn = null;
    [SerializeField] private Button cancelBtn = null;

    #endregion Varibles

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        titleUI = uiBase as TitleUI;

        createRoomBtn.onClick.AddListener(OnClickCreateRoomBtn);
        publicJoinBtn.onClick.AddListener(OnClickPublicJoinBtn);
        privateJoinBtn.onClick.AddListener(OnClickPrivateJoinBtn);
        cancelBtn.onClick.AddListener(OnClickCancelBtn);

        nicknameInputField.onValueChanged.AddListener(OnNicknameChanged);

        OnActive += (() =>
        {
            if (PhotonNetwork.LocalPlayer.NickName == string.Empty) { return; }

            nicknameInputField.text = PhotonNetwork.LocalPlayer.NickName;
        });
    }

    public void OnClickCreateRoomBtn() 
    {
        if (!IsValidNickname()) { return; }

        PhotonNetwork.LocalPlayer.NickName = nicknameInputField.text;
        titleUI.TurnOnPanel(ETitleUIPanel.CREATEROOM); 
    }

    public void OnClickPublicJoinBtn() 
    {
        if (!IsValidNickname()) { return; }

        PhotonNetwork.LocalPlayer.NickName = nicknameInputField.text;
        titleUI.TurnOnPanel(ETitleUIPanel.PUBLICJOIN); 
    }

    public void OnClickPrivateJoinBtn() 
    {
        if (!IsValidNickname()) { return; }

        PhotonNetwork.LocalPlayer.NickName = nicknameInputField.text;
        titleUI.TurnOnPanel(ETitleUIPanel.PRIVATEJOIN); 
    }

    public void OnClickCancelBtn() { titleUI.TurnOnPanel(ETitleUIPanel.START); }

    private void OnNicknameChanged(string value)
    {
        nicknameInputField.text = Regex.Replace(value, @"[^0-9a-zA-Z¤¡-ÆR]", "");

        if (System.Text.Encoding.Unicode.GetByteCount(value) > 16)        
        {
            nicknameInputField.text = value.Substring(0, value.Length - 1);        
        }
    }

    private bool IsValidNickname()
    {
        if (nicknameInputField.text.Length == 0) { return false; }
        
        return true;
    }

    #endregion Methods
}
