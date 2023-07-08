using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

using PhotonHashTable = ExitGames.Client.Photon.Hashtable;

public class PlayRuleGroup : MonoBehaviour
{
    #region Variables

    [SerializeField] private Toggle shortDistanceVoiceToggle = null;
    [SerializeField] private Toggle randomStartPointToggle = null;
    [SerializeField] private Toggle hideEmissionInfoToggle = null;
    [SerializeField] private Toggle blindMafiaModeToggle = null;
    [SerializeField] private Toggle openVoteResultToggle = null;

    [SerializeField] private Dropdown normalSightDropdown = null;
    [SerializeField] private Dropdown mafiaSightDropdown = null;
    [SerializeField] private Dropdown neutralSightDropdown = null;
    [SerializeField] private Dropdown moveSpeedDropdown = null;

    #endregion Variables

    #region Methods

    public void InitGroup()
    {
        PhotonHashTable roomSetting = PhotonNetwork.CurrentRoom.CustomProperties;

        shortDistanceVoiceToggle.isOn = (bool)roomSetting[CustomProperties.SHORT_DISTANCE_VOICE];
        randomStartPointToggle.isOn = (bool)roomSetting[CustomProperties.RANDOM_START_POINT];
        hideEmissionInfoToggle.isOn = (bool)roomSetting[CustomProperties.HIDE_EMISSION_INFO];
        blindMafiaModeToggle.isOn = (bool)roomSetting[CustomProperties.BLIND_MAFIA_MODE];
        openVoteResultToggle.isOn = (bool)roomSetting[CustomProperties.OPEN_VOTE_RESULT];

        normalSightDropdown.value = (int)roomSetting[CustomProperties.NORMAL_SIGHT];
        mafiaSightDropdown.value = (int)roomSetting[CustomProperties.MAFIA_SIGHT];
        neutralSightDropdown.value = (int)roomSetting[CustomProperties.NEUTRAL_SIGHT];
        moveSpeedDropdown.value = (int)roomSetting[CustomProperties.MOVE_SPEED];

        shortDistanceVoiceToggle.onValueChanged.AddListener(OnShortDistanceVoiceChanged);
        randomStartPointToggle.onValueChanged.AddListener(OnRandomStartPointChanged);
        hideEmissionInfoToggle.onValueChanged.AddListener(OnHideEmissionInfoChanged);
        blindMafiaModeToggle.onValueChanged.AddListener(OnBlindMafiaModeChanged);
        openVoteResultToggle.onValueChanged.AddListener(OnOpenVoteResultChanged);

        normalSightDropdown.onValueChanged.AddListener(OnNormalSightChanged);
        mafiaSightDropdown.onValueChanged.AddListener(OnMafiaSightChanged);
        neutralSightDropdown.onValueChanged.AddListener(OnNeutralSightChanged);
        moveSpeedDropdown.onValueChanged.AddListener(OnMoveSpeedChanged);
    }

    public void OnShortDistanceVoiceChanged(bool value)
    {
        PhotonHashTable roomSetting = PhotonNetwork.CurrentRoom.CustomProperties;
        roomSetting[CustomProperties.SHORT_DISTANCE_VOICE] = value;
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomSetting);
    }

    public void OnRandomStartPointChanged(bool value)
    {
        PhotonHashTable roomSetting = PhotonNetwork.CurrentRoom.CustomProperties;
        roomSetting[CustomProperties.RANDOM_START_POINT] = value;
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomSetting);
    }

    public void OnHideEmissionInfoChanged(bool value)
    {
        PhotonHashTable roomSetting = PhotonNetwork.CurrentRoom.CustomProperties;
        roomSetting[CustomProperties.HIDE_EMISSION_INFO] = value;
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomSetting);
    }

    public void OnBlindMafiaModeChanged(bool value)
    {
        PhotonHashTable roomSetting = PhotonNetwork.CurrentRoom.CustomProperties;
        roomSetting[CustomProperties.BLIND_MAFIA_MODE] = value;
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomSetting);
    }

    public void OnOpenVoteResultChanged(bool value)
    {
        PhotonHashTable roomSetting = PhotonNetwork.CurrentRoom.CustomProperties;
        roomSetting[CustomProperties.OPEN_VOTE_RESULT] = value;
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomSetting);
    }

    public void OnNormalSightChanged(int idx)
    {
        PhotonHashTable roomSetting = PhotonNetwork.CurrentRoom.CustomProperties;
        roomSetting[CustomProperties.NORMAL_SIGHT] = idx;
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomSetting);
    }

    public void OnMafiaSightChanged(int idx)
    {
        PhotonHashTable roomSetting = PhotonNetwork.CurrentRoom.CustomProperties;
        roomSetting[CustomProperties.MAFIA_SIGHT] = idx;
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomSetting);
    }

    public void OnNeutralSightChanged(int idx)
    {
        PhotonHashTable roomSetting = PhotonNetwork.CurrentRoom.CustomProperties;
        roomSetting[CustomProperties.NEUTRAL_SIGHT] = idx;
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomSetting);
    }

    public void OnMoveSpeedChanged(int idx)
    {
        PhotonHashTable roomSetting = PhotonNetwork.CurrentRoom.CustomProperties;
        roomSetting[CustomProperties.MOVE_SPEED] = idx;
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomSetting);
    }

    #endregion Methods
}
