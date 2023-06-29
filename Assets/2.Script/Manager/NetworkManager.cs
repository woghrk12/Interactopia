using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class NetworkManager : SingletonMonobehaviourPunCallback<NetworkManager>
{
    #region Variables

    private static bool isInitialized = false;

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
        
    }
    #endregion Photon Callbacks
}
