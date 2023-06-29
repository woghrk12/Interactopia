using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class TestPhoton : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject playerPrefab;
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        RoomOptions roomOptions = new();
        PhotonNetwork.JoinOrCreateRoom("testRoom1", roomOptions, null);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(this.playerPrefab.name, Vector3.zero, Quaternion.identity);
    }
}
