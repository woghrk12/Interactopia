using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class PublicJoinPanel : UIPanel
{
    #region Variables

    private static readonly int MAX_ROOM_LIST = 30;

    private TitleUI titleUI = null;

    [SerializeField] private Button joinBtn = null;
    [SerializeField] private Button cancelBtn = null;

    private RoomInfo selectedRoomInfo = null;

    [SerializeField] private GameObject roomObjDictParent = null;
    [SerializeField] private GameObject roomPrefab = null;

    private Dictionary<string, GameObject> roomObjDict = new();

    #endregion Variables

    #region Unity Events

    private void OnEnable()
    {
        var networkManager = NetworkManager.Instance;

        networkManager.RoomListAdded += AddRoomListObject;
        networkManager.RoomListRemoved += RemoveRoomlistObject;
        networkManager.RoomListUpdated += UpdateRoomListObject;

        selectedRoomInfo = null;

        AddRoomListObject(networkManager.RoomList);
    }

    private void OnDisable()
    {
        var networkManager = NetworkManager.Instance;

        networkManager.RoomListAdded -= AddRoomListObject;
        networkManager.RoomListRemoved -= RemoveRoomlistObject;
        networkManager.RoomListUpdated -= UpdateRoomListObject;
    }

    #endregion Unity Events

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        titleUI = uiBase as TitleUI;

        joinBtn.onClick.AddListener(OnClickJoinBtn);
        cancelBtn.onClick.AddListener(OnClickCancelBtn);
    }

    public void OnClickJoinBtn() 
    {
        NetworkManager.JoinRoom(selectedRoomInfo);
    }

    public void OnClickCancelBtn() { titleUI.TurnOnPanel(ETitleUIPanel.LOBBY); }

    public void OnClickRoomItem(RoomInfo roomInfo) { selectedRoomInfo = roomInfo; }

    private void AddRoomListObject(List<RoomInfo> addedList)
    {
        foreach (RoomInfo room in addedList)
        {
            if (roomObjDict.Count > MAX_ROOM_LIST) break;

            var roomInstance = Instantiate(roomPrefab, roomObjDictParent.transform).GetComponent<RoomItemBtn>();
            roomInstance.SetRoomItem(room);
            roomInstance.SelectBtn.onClick.AddListener(() => OnClickRoomItem(room));
            roomObjDict.Add(room.Name, roomInstance.gameObject);
        }
    }

    private void RemoveRoomlistObject(List<RoomInfo> removedList)
    {
        foreach (RoomInfo room in removedList)
        {
            if (roomObjDict.TryGetValue(room.Name, out GameObject roomObj))
            {
                roomObjDict.Remove(room.Name);
                Destroy(roomObj);
            }
        }
    }

    private void UpdateRoomListObject(List<RoomInfo> updatedList)
    {
        foreach (RoomInfo room in updatedList)
        {
            if (roomObjDict.TryGetValue(room.Name, out GameObject roomObj))
            {
                roomObj.GetComponent<RoomItemBtn>().SetRoomItem(room);
            }
        }
    }

    #endregion Methods
}
