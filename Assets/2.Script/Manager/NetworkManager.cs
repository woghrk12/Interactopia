using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class NetworkManager : SingletonMonobehaviourPunCallback<NetworkManager>
{
    #region Variables

    private static bool isInitialized = false;

    private List<RoomInfo> roomList = new List<RoomInfo>();

    [SerializeField] private Text statusText = null;

    public Action<List<RoomInfo>> RoomListAdded = null;
    public Action<List<RoomInfo>> RoomListRemoved = null;
    public Action<List<RoomInfo>> RoomListUpdated = null;

    public Action<int> MaxPlayerChanged = null;
    public Action<int> MaxMafiaChanged = null;
    public Action<int> MaxNeutralChanged = null;

    public Action<bool> ShortDistanceVoiceChanged = null;
    public Action<bool> RandomStartPointChanged = null;
    public Action<bool> HideEmissionInfoChanged = null;
    public Action<bool> BlindMafiaModeChanged = null;
    public Action<bool> OpenVoteResultChanged = null;

    public Action<string> NormalSightChanged = null;
    public Action<string> MafiaSightChanged = null;
    public Action<string> NeutralSightChanged = null;
    public Action<string> MoveSpeedChanged = null;

    public Action<int> CurPlayersChanged = null;

    #endregion Variables

    #region Properties

    public static bool IsInitialized => isInitialized;

    public List<RoomInfo> RoomList => roomList;

    #endregion Properties

    #region Unity Events

    private void Update()
    {
        statusText.text = PhotonNetwork.NetworkClientState.ToString();
    }

    #endregion Unity Events

    #region Methods

    public static void Connect()
    {
        if (PhotonNetwork.IsConnected) { return; }

        PhotonNetwork.ConnectUsingSettings();
    }

    public static void CreateRooom(string roomName, RoomOptions roomOption) => PhotonNetwork.CreateRoom(roomName, roomOption);

    public static void JoinRoom(string roomName) => PhotonNetwork.JoinRoom(roomName);

    #endregion Methods

    #region Photon Callbacks

    public override void OnConnectedToMaster()
    {
        if (!isInitialized) 
        {
            GameManager.OnConnectedServer();
            isInitialized = true;
        }

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.LocalPlayer.NickName = "Test";
    }

    public override void OnJoinedRoom()
    {
        GameManager.OnJoinedRoom();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        var addedRoomList = new List<RoomInfo>();
        var removedRoomList = new List<RoomInfo>();
        var updatedRoomList = new List<RoomInfo>();
        
        foreach (RoomInfo room in roomList)
        {
            if (room.RemovedFromList)
            {
                this.roomList.Remove(room);
                removedRoomList.Add(room);
                continue;   
            }

            int idx = this.roomList.FindIndex(x => x.Equals(room));
            if (idx > 0) 
            {
                this.roomList[idx] = room;
                updatedRoomList.Add(room);
            }
            else 
            {
                this.roomList.Add(room);
                addedRoomList.Add(room);
            }
        }

        RoomListAdded?.Invoke(addedRoomList);
        RoomListRemoved?.Invoke(removedRoomList);
        RoomListUpdated?.Invoke(updatedRoomList);
    }

    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
    {
        MaxPlayerChanged?.Invoke(PhotonNetwork.CurrentRoom.MaxPlayers);
        MaxMafiaChanged?.Invoke((int)propertiesThatChanged["MaxMafia"]);
        MaxNeutralChanged?.Invoke((int)propertiesThatChanged["MaxNeutral"]);

        ShortDistanceVoiceChanged?.Invoke((bool)propertiesThatChanged["ShortDistanceVoice"]);
        RandomStartPointChanged?.Invoke((bool)propertiesThatChanged["RandomStartPoint"]);
        HideEmissionInfoChanged?.Invoke((bool)propertiesThatChanged["HideEmissionInfo"]);
        BlindMafiaModeChanged?.Invoke((bool)propertiesThatChanged["BlindMafiaMode"]);
        OpenVoteResultChanged?.Invoke((bool)propertiesThatChanged["OpenVoteResult"]);

        NormalSightChanged?.Invoke((string)propertiesThatChanged["NormalSight"]);
        MafiaSightChanged?.Invoke((string)propertiesThatChanged["MafiaSight"]);
        NeutralSightChanged?.Invoke((string)propertiesThatChanged["NeutralSight"]);
        MoveSpeedChanged?.Invoke((string)propertiesThatChanged["MoveSpeed"]);
}

    #endregion Photon Callbacks
}
