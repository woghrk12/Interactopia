using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

using PhotonHashTable = ExitGames.Client.Photon.Hashtable;

public class CreateRoomPanel : UIPanel
{
    #region Variables

    private const int MAX_PLAYER = 16;
    private const int MIN_PLAYER = 5;

    private TitleUI titleUI = null;

    [Range(MIN_PLAYER, MAX_PLAYER)] private int maxPlayer = 10;

    [SerializeField] private Button createBtn = null;
    [SerializeField] private Button cancelBtn = null;
    [SerializeField] private Slider maxPlayerSlider = null;
    [SerializeField] private Text maxPlayerText = null;
    [SerializeField] private Toggle privacyModeToggle = null;

    #endregion Variables

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        titleUI = uiBase as TitleUI;

        createBtn.onClick.AddListener(OnClickCreateBtn);
        cancelBtn.onClick.AddListener(OnClickCancelBtn);

        maxPlayerSlider.value = maxPlayer;
        maxPlayerSlider.onValueChanged.AddListener(OnMaxPlayerChanged);

        privacyModeToggle.isOn = false;
    }

    public void OnClickCreateBtn()
    {
        // Custom Room Properties
        PhotonHashTable propertyList = new();
        propertyList.Add("RoomName", PhotonNetwork.LocalPlayer.NickName);
        propertyList.Add("MaxMafias", 1);
        propertyList.Add("MaxNeutrals", 1);

        // Custom Room Properties for Lobby
        string[] propertyListForLobby = new string[0];
        propertyListForLobby = ArrayHelper.Add("RoomName", propertyListForLobby);
        propertyListForLobby = ArrayHelper.Add("MaxMafias", propertyListForLobby);

        string roomName = Utilities.ComputeMD5(PhotonNetwork.LocalPlayer.UserId + "_" + System.DateTime.UtcNow.ToFileTime().ToString(), 3);
        RoomOptions roomOption = new RoomOptions { 
            MaxPlayers = maxPlayer, 
            IsVisible = !privacyModeToggle.isOn, 
            IsOpen = true,
            CustomRoomProperties = propertyList, 
            CustomRoomPropertiesForLobby = propertyListForLobby 
        };            

        NetworkManager.CreateRooom(roomName, roomOption);
    }

    public void OnClickCancelBtn() { titleUI.TurnOnPanel(ETitleUIPanel.LOBBY); }

    public void OnMaxPlayerChanged(float value) 
    {
        maxPlayer = (int)value;
        maxPlayerText.text = maxPlayer.ToString(); 
    }

    #endregion Methods
}
