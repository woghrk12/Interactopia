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

        shortDistanceVoiceToggle.isOn = (bool)roomSetting["ShortDistanceVoice"];
        randomStartPointToggle.isOn = (bool)roomSetting["RandomStartPoint"];
        hideEmissionInfoToggle.isOn = (bool)roomSetting["HideEmissionInfo"];
        blindMafiaModeToggle.isOn = (bool)roomSetting["BlindMafiaMode"];
        openVoteResultToggle.isOn = (bool)roomSetting["OpenVoteResult"];

        normalSightDropdown.value = (int)roomSetting["NormalSight"];
        mafiaSightDropdown.value = (int)roomSetting["MafiaSight"];
        neutralSightDropdown.value = (int)roomSetting["NeutralSight"];
        moveSpeedDropdown.value = (int)roomSetting["MoveSpeed"];

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
        => PhotonNetwork.CurrentRoom.CustomProperties["ShortDistanceVoice"] = value;

    public void OnRandomStartPointChanged(bool value)
        => PhotonNetwork.CurrentRoom.CustomProperties["RandomStartPoint"] = value;

    public void OnHideEmissionInfoChanged(bool value)
        => PhotonNetwork.CurrentRoom.CustomProperties["HideEmissionInfo"] = value;

    public void OnBlindMafiaModeChanged(bool value)
        => PhotonNetwork.CurrentRoom.CustomProperties["BlindMafiaMode"] = value;

    public void OnOpenVoteResultChanged(bool value)
        => PhotonNetwork.CurrentRoom.CustomProperties["OpenVoteResult"] = value;

    public void OnNormalSightChanged(int idx)
        => PhotonNetwork.CurrentRoom.CustomProperties["NormalSight"] = idx;

    public void OnMafiaSightChanged(int idx)
        => PhotonNetwork.CurrentRoom.CustomProperties["MafiaSight"] = idx;

    public void OnNeutralSightChanged(int idx)
        => PhotonNetwork.CurrentRoom.CustomProperties["NeutralSight"] = idx;

    public void OnMoveSpeedChanged(int idx)
        => PhotonNetwork.CurrentRoom.CustomProperties["MoveSpeed"] = idx;

    #endregion Methods
}
