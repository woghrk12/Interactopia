using UnityEngine;
using Photon.Pun;

public class NetworkManager : SingletonMonobehaviourPunCallback<NetworkManager>
{
    #region Variables

    private static bool isInitialized = false;

    #endregion Variables

    #region Properties

    public static bool IsInitialized => isInitialized;

    #endregion Properties

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
    }

    #endregion Photon Callbacks
}
