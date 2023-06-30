using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;


public class RoomItemBtn : MonoBehaviour
{
    #region Variables

    [SerializeField] private Image mapIcon = null;
    [SerializeField] private Text roomNameText = null;
    [SerializeField] private Text roomModeText = null;
    [SerializeField] private Text playerNumText = null;

    #endregion Variables

    #region Methods

    public void SetRoomItem(RoomInfo roomInfo)
    {
        roomNameText.text = roomInfo.Name;
        playerNumText.text = $"{roomInfo.PlayerCount.ToString()} / {roomInfo.MaxPlayers.ToString()}";
    }
    
    #endregion Methods
}
