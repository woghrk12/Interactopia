using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class PublicJoinPanel : UIPanel
{
    #region Variables

    private static readonly int MAX_ROOM_LIST = 30;

    private TitleUI titleUI = null;

    [SerializeField] private Button joinBtn = null;
    [SerializeField] private Button cancelBtn = null;

    [SerializeField] private GameObject roomObjDictParent = null;
    [SerializeField] private GameObject roomPrefab = null;

    private Dictionary<string, GameObject> roomObjDict = new();

    #endregion Variables

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        titleUI = uiBase as TitleUI;

        joinBtn.onClick.AddListener(OnClickJoinBtn);
        cancelBtn.onClick.AddListener(OnClickCancelBtn);
    }

    public void OnClickJoinBtn() { SceneManager.LoadScene(1); }

    public void OnClickCancelBtn() { titleUI.TurnOnPanel(ETitleUIPanel.LOBBY); }

    public override IEnumerator OnActivePanel()
    {
        var networkManager = NetworkManager.Instance;

        networkManager.RoomListAdded += AddRoomListObject;
        networkManager.RoomListRemoved += RemoveRoomlistObject;
        networkManager.RoomListUpdated += UpdateRoomListObject;

        // TODO : implement panel effects
        yield return null;
    }

    public override IEnumerator OnDeactivePanel()
    {
        var networkManager = NetworkManager.Instance;

        networkManager.RoomListAdded -= AddRoomListObject;
        networkManager.RoomListRemoved -= RemoveRoomlistObject;
        networkManager.RoomListUpdated -= UpdateRoomListObject;

        // TODO : implement panel effects
        yield return null;
    }

    private void AddRoomListObject(List<RoomInfo> addedList)
    {
        foreach (RoomInfo room in addedList)
        {
            if (roomObjDict.Count > MAX_ROOM_LIST) break;

            GameObject roomInstance = Instantiate(roomPrefab, roomObjDictParent.transform);
            roomInstance.GetComponent<RoomItemBtn>().SetRoomItem(room);
            roomObjDict.Add(room.Name, roomInstance);
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
