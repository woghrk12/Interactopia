using UnityEngine;
using UnityEngine.UI;

using PhotonHashTable = ExitGames.Client.Photon.Hashtable;

public class GuestRuleSettingPanel : UIPanel
{
    #region Variables

    private InGameUI inGameUI = null;

    [SerializeField] private Image backgroundImg = null;
    [SerializeField] private Button closeBtn = null;

    #endregion Variables

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        inGameUI = uiBase as InGameUI;

        backgroundImg.GetComponent<Button>().onClick.AddListener(OnClickCloseBtn);
        closeBtn.onClick.AddListener(OnClickCloseBtn);
    }

    public void OnClickCloseBtn() { inGameUI.TurnOffPanel(EInGamePanel.GUESTRULESETTING); }

    #endregion Methods

    #region Photon Events

    public override void OnRoomPropertiesUpdate(PhotonHashTable propertiesThatChanged)
    {
        /*
        MaxPlayerChanged?.Invoke(PhotonNetwork.CurrentRoom.MaxPlayers);
        MaxMafiaChanged?.Invoke((int)propertiesThatChanged[CustomProperties.MAX_MAFIAS]);
        MaxNeutralChanged?.Invoke((int)propertiesThatChanged[CustomProperties.MAX_NEUTRALS]);

        ShortDistanceVoiceChanged?.Invoke((bool)propertiesThatChanged[CustomProperties.SHORT_DISTANCE_VOICE]);
        RandomStartPointChanged?.Invoke((bool)propertiesThatChanged[CustomProperties.RANDOM_START_POINT]);
        HideEmissionInfoChanged?.Invoke((bool)propertiesThatChanged[CustomProperties.HIDE_EMISSION_INFO]);
        BlindMafiaModeChanged?.Invoke((bool)propertiesThatChanged[CustomProperties.BLIND_MAFIA_MODE]);
        OpenVoteResultChanged?.Invoke((bool)propertiesThatChanged[CustomProperties.OPEN_VOTE_RESULT]);

        NormalSightChanged?.Invoke((string)propertiesThatChanged[CustomProperties.NORMAL_SIGHT]);
        MafiaSightChanged?.Invoke((string)propertiesThatChanged[CustomProperties.MAFIA_SIGHT]);
        NeutralSightChanged?.Invoke((string)propertiesThatChanged[CustomProperties.NEUTRAL_SIGHT]);
        MoveSpeedChanged?.Invoke((string)propertiesThatChanged[CustomProperties.MOVE_SPEED]);
         */
    }

    #endregion Photon Events
}
