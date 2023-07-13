using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public enum EScene { NONE = -1, TITLE, INGAME, END }

public class GameManager : SingletonMonobehaviourPunCallback<GameManager>
{
    #region Unity Events

    private void Start()
    {
        SceneManager.sceneLoaded += OnLoadedScene;
    }

    #endregion Unity Events

    #region Event Callbacks

    private void OnLoadedScene(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == (int)EScene.TITLE)
        {
            TitleUI titleUI = UIBase.Instance as TitleUI;
            titleUI.InitBase();
        }
        else if (scene.buildIndex == (int)EScene.INGAME)
        {
            InGameUI inGameUI = UIBase.Instance as InGameUI;
            inGameUI.InitBase();
        }
    }

    #endregion Event Callbacks

    #region Photon Callbacks

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();

        if (NetworkManager.IsInitialized) { return; }

        EScene curScene = (EScene)SceneManager.GetActiveScene().buildIndex;

        if (curScene == EScene.TITLE)
        {
            TitleUI titleUI = UIBase.Instance as TitleUI;
            titleUI.TurnOffPanel(ETitleUIPanel.LOADING);
            titleUI.InitBase();
        }
        else if (curScene == EScene.INGAME)
        {
            InGameUI inGameUI = UIBase.Instance as InGameUI;
            inGameUI.TurnOffPanel(EInGamePanel.LOADING);
            inGameUI.InitBase();
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        if (cause == DisconnectCause.ApplicationQuit) { return; }

        EScene curScene = (EScene)SceneManager.GetActiveScene().buildIndex;

        if (curScene == EScene.TITLE)
        {
            TitleUI titleUI = UIBase.Instance as TitleUI;
            titleUI.TurnOnPanel(ETitleUIPanel.LOADING);
        }
        else if (curScene == EScene.INGAME)
        {
            InGameUI inGameUI = UIBase.Instance as InGameUI;
            inGameUI.TurnOnPanel(EInGamePanel.LOADING);
        }

        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene((int)EScene.INGAME);
    }

    #endregion Photon Callbacks
}
