using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EScene { NONE = -1, TITLE, INGAME, END }

public class GameManager : SingletonMonobehaviour<GameManager>
{
    #region Unity Events

    private void Start()
    {
        SceneManager.sceneLoaded += OnLoadedScene;

        if (SceneManager.GetActiveScene().buildIndex == (int)EScene.TITLE)
        {
            TitleUI titleUI = UIBase.Instance as TitleUI;
            titleUI.InitBase();
        }

        NetworkManager.Connect();
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

    public static void OnConnectedServer()
    {
        if (SceneManager.GetActiveScene().buildIndex == (int)EScene.TITLE)
        {
            TitleUI titleUI = UIBase.Instance as TitleUI;
            titleUI.TurnOnPanel(ETitleUIPanel.START, true);
        }
    }

    public static void OnJoinedRoom()
    {
        SceneManager.LoadScene((int)EScene.INGAME);
    }

    #endregion Event Callbacks
}
