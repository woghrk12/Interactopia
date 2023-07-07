using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public enum EScene { NONE = -1, TITLE, INGAME, END }

public class GameManager : SingletonMonobehaviourPunCallback<GameManager>
{
    #region Variables

    private static bool isInitialized = false;

    #endregion Variables

    #region Unity Events

    private void Start()
    {
        SceneManager.sceneLoaded += OnLoadedScene;

        if (SceneManager.GetActiveScene().buildIndex == (int)EScene.TITLE)
        {
            TitleUI titleUI = UIBase.Instance as TitleUI;
            titleUI.InitBase();
        }

        PhotonNetwork.ConnectUsingSettings();
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
        if (isInitialized) { return; }

        PhotonNetwork.JoinLobby();

        TitleUI titleUI = UIBase.Instance as TitleUI;
        titleUI.TurnOnPanel(ETitleUIPanel.START);
        isInitialized = true;
    }

    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene((int)EScene.INGAME);
    }

    #endregion Photon Callbacks
}
