using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public struct RoomOption
{
    public string roomName;
    public RoomOptions roomOptions;

    public RoomOption(string roomName, RoomOptions roomOptions)
    {
        this.roomName = roomName;
        this.roomOptions = roomOptions;
    }
}

public class NetworkManager : SingletonMonobehaviourPunCallback<NetworkManager>
{
    #region Variables

    private static bool isInitialized = false;

    private List<RoomInfo> roomList = new List<RoomInfo>();

    public Action<List<RoomInfo>> RoomListAdded = null;
    public Action<List<RoomInfo>> RoomListRemoved = null;
    public Action<List<RoomInfo>> RoomListUpdated = null;

    [SerializeField] private Text statusText = null;

    #endregion Variables

    #region Properties

    public static bool IsInitialized => isInitialized;

    #endregion Properties

    #region Unity Events

    private void Update()
    {
        statusText.text = PhotonNetwork.NetworkClientState.ToString();
    }

    #endregion Unity Events

    #region Methods

    public static void Connect() => PhotonNetwork.ConnectUsingSettings();

    public static void CreateRooom(RoomOption roomOption) => PhotonNetwork.CreateRoom(roomOption.roomName, roomOption.roomOptions);

    #endregion Methods

    #region Photon Callbacks

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnected");

        if (!isInitialized) 
        {
            GameManager.OnConnectedServer();
            isInitialized = true;
        }

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedRoom()
    {
        GameManager.OnJoinedRoom();
        Debug.Log(PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("OnRoomListUpdate");
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

    #endregion Photon Callbacks
}
