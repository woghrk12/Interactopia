using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using DG.Tweening;

using PhotonHashTable = ExitGames.Client.Photon.Hashtable;

public class RoomPanel : UIPanel
{
    #region Variables

    private InGameUI inGameUI = null;

    [SerializeField] private Text roomCodeText = null;
    [SerializeField] private Text maxPlayersText = null;
    [SerializeField] private Text curPlayersText = null;
    [SerializeField] private Button settingBtn = null;
    [SerializeField] private Button textChattingBtn = null;
    [SerializeField] private Button ruleSettingBtn = null;
    [SerializeField] private Button startBtn = null;

    #endregion Variables

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        inGameUI = uiBase as InGameUI;

        settingBtn.onClick.AddListener(OnClickSettingBtn);
        textChattingBtn.onClick.AddListener(OnClickTextChattingBtn);
        ruleSettingBtn.onClick.AddListener(OnClickRuleSettingBtn);
        startBtn.onClick.AddListener(OnClickStartBtn);

        Room currentRoom = PhotonNetwork.CurrentRoom;

        roomCodeText.text = $"Code\n{currentRoom.Name}";
        curPlayersText.text = currentRoom.PlayerCount.ToString();
        maxPlayersText.text = currentRoom.MaxPlayers.ToString();
    }

    #endregion Methods

    #region Override Methods

    public override Sequence ActiveAnimation()
    {
        return DOTween.Sequence();
    }

    public override Sequence DeactiveAnimation()
    {
        return DOTween.Sequence();
    }

    #endregion Override Methods

    #region Event Methods

    public void OnClickSettingBtn() => inGameUI.TurnOnPanel(EInGamePanel.SETTING); 

    public void OnClickTextChattingBtn() => inGameUI.TurnOnPanel(EInGamePanel.TEXTCHATTING); 

    public void OnClickRuleSettingBtn()
    {
        if (PhotonNetwork.IsMasterClient) { inGameUI.TurnOnPanel(EInGamePanel.HOSTRULESETTING); }
        else { inGameUI.TurnOnPanel(EInGamePanel.GUESTRULESETTING); }
    }

    public void OnClickStartBtn() => inGameUI.TurnOnPanel(EInGamePanel.GAMESTART); 

    public void OnCurPlayerNumChanged(int value) => curPlayersText.text = value.ToString();

    public void OnMaxPlayerNumChanged(int value) => maxPlayersText.text = value.ToString();

    #endregion Event Methods

    #region Photon Events

    public override void OnRoomPropertiesUpdate(PhotonHashTable propertiesThatChanged)
    {
        maxPlayersText.text = PhotonNetwork.CurrentRoom.MaxPlayers.ToString();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        curPlayersText.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        curPlayersText.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString();
    }

    #endregion Photon Events
}
