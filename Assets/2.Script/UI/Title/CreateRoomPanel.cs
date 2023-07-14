using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using DG.Tweening;

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

    private void CreateRoom()
    {
        // Custom Room Properties
        PhotonHashTable propertyList = new();
        propertyList.Add(CustomProperties.ROOM_NAME, PhotonNetwork.LocalPlayer.NickName);
        propertyList.Add(CustomProperties.MAX_MAFIAS, 1);
        propertyList.Add(CustomProperties.MAX_NEUTRALS, 1);

        propertyList.Add(CustomProperties.SHORT_DISTANCE_VOICE, true);
        propertyList.Add(CustomProperties.RANDOM_START_POINT, false);
        propertyList.Add(CustomProperties.HIDE_EMISSION_INFO, false);
        propertyList.Add(CustomProperties.BLIND_MAFIA_MODE, false);
        propertyList.Add(CustomProperties.OPEN_VOTE_RESULT, true);

        propertyList.Add(CustomProperties.NORMAL_SIGHT, 0);
        propertyList.Add(CustomProperties.MAFIA_SIGHT, 0);
        propertyList.Add(CustomProperties.NEUTRAL_SIGHT, 0);
        propertyList.Add(CustomProperties.MOVE_SPEED, 0);

        propertyList.Add(CustomProperties.KILL_COOLDOWN, 10);
        propertyList.Add(CustomProperties.SABOTAGE_COOLDOWN, 10);
        propertyList.Add(CustomProperties.EMERGENCY_MEETING_COOLDOWN, 20);
        propertyList.Add(CustomProperties.MEETING_TIME, 100);
        propertyList.Add(CustomProperties.VOTE_TIME, 50);

        // Custom Room Properties for Lobby
        string[] propertyListForLobby = new string[0];
        propertyListForLobby = ArrayHelper.Add(CustomProperties.ROOM_NAME, propertyListForLobby);
        propertyListForLobby = ArrayHelper.Add(CustomProperties.MAX_MAFIAS, propertyListForLobby);

        string roomName = Utilities.ComputeMD5(PhotonNetwork.LocalPlayer.UserId + "_" + System.DateTime.UtcNow.ToFileTime().ToString(), 3);
        RoomOptions roomOption = new RoomOptions
        {
            MaxPlayers = maxPlayer,
            IsVisible = !privacyModeToggle.isOn,
            IsOpen = true,
            CustomRoomProperties = propertyList,
            CustomRoomPropertiesForLobby = propertyListForLobby
        };

        PhotonNetwork.CreateRoom(roomName, roomOption);
    }

    #endregion Methods

    #region Override Methods

    public override Sequence ActiveAnimation()
    {
        return DOTween.Sequence().Append(titleUI.FadeIn(0.5f));
    }

    public override Sequence DeactiveAnimation()
    {
        return DOTween.Sequence().Append(titleUI.FadeOut(0.5f));
    }

    #endregion Override Methods

    #region Event Methods

    public void OnClickCreateBtn() => CreateRoom();

    public void OnClickCancelBtn() => titleUI.OpenPanel(ETitleUIPanel.LOBBY, ETitleUIPanel.CREATEROOM);

    public void OnMaxPlayerChanged(float value) 
    {
        maxPlayer = (int)value;
        maxPlayerText.text = maxPlayer.ToString(); 
    }

    #endregion Event Methods

    #region Photon Events

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        switch (returnCode)
        {
            case ErrorCode.GameIdAlreadyExists:
                {
                    CreateRoom();
                    break;
                }
        }
    }

    #endregion Photon Events
}
