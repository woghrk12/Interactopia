using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : SingletonMonobehaviourPunCallback<NetworkManager>
{
    #region Variables

    private static bool isInitialized = false;

    private List<RoomInfo> roomList = new List<RoomInfo>();

    [SerializeField] private Text statusText = null;

    public Action<List<RoomInfo>> RoomListAdded = null;
    public Action<List<RoomInfo>> RoomListRemoved = null;
    public Action<List<RoomInfo>> RoomListUpdated = null;

    #endregion Variables

    #region Properties

    public static bool IsInitialized => isInitialized;

    public List<RoomInfo> RoomList => roomList;

    #endregion Properties

    #region Unity Events

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    private void Update()
    {
        statusText.text = PhotonNetwork.NetworkClientState.ToString();
    }

    #endregion Unity Events

    #region Photon Callbacks

    public override void OnConnectedToMaster()
    {
        isInitialized = true;
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.LocalPlayer.NickName = "Test";
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

    #endregion Photon Callbacks
}
