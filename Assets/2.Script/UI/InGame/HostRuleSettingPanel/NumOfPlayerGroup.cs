using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

using PhotonHashTable = ExitGames.Client.Photon.Hashtable;

public class NumOfPlayerGroup : MonoBehaviour
{
    #region Variables

    [SerializeField] private Slider maxPlayerSlider = null;
    [SerializeField] private Slider maxMafiaSlider = null;
    [SerializeField] private Slider maxNeutralSlider = null;

    [SerializeField] private Text maxPlayerText = null;
    [SerializeField] private Text maxMafiaText = null;
    [SerializeField] private Text maxNeutralText = null;

    #endregion Variables

    #region Methods

    public void InitGroup()
    {
        NetworkManager networkManager = NetworkManager.Instance;

        Room currentRoom = PhotonNetwork.CurrentRoom;
        PhotonHashTable roomSetting = currentRoom.CustomProperties;

        int maxPlayers = currentRoom.MaxPlayers;
        maxPlayerSlider.value = maxPlayers;
        maxPlayerText.text = maxPlayers.ToString();

        int maxMafias = (int)roomSetting[CustomProperties.MAX_MAFIAS];
        maxMafiaSlider.value = maxMafias;
        maxMafiaText.text = maxMafias.ToString();

        int maxNeutrals = (int)roomSetting[CustomProperties.MAX_NEUTRALS];
        maxNeutralSlider.value = maxNeutrals;
        maxNeutralText.text = maxNeutrals.ToString();

        maxPlayerSlider.onValueChanged.AddListener(OnMaxPlayersChanged);
        maxMafiaSlider.onValueChanged.AddListener(OnMaxMafiasChanged);
        maxNeutralSlider.onValueChanged.AddListener(OnMaxNeutralsChanged);
    }

    public void OnMaxPlayersChanged(float value)
    {
        int maxPlayers = (int)value;
        PhotonNetwork.CurrentRoom.MaxPlayers = maxPlayers;
        maxPlayerText.text = maxPlayers.ToString();
    }

    public void OnMaxMafiasChanged(float value)
    {
        int maxMafias = (int)value;
        PhotonHashTable roomSetting = PhotonNetwork.CurrentRoom.CustomProperties;

        roomSetting[CustomProperties.MAX_MAFIAS] = maxMafias;

        PhotonNetwork.CurrentRoom.SetCustomProperties(roomSetting);
        maxMafiaText.text = maxMafias.ToString();
    }

    public void OnMaxNeutralsChanged(float value)
    {
        int maxNeutrals = (int)value;
        PhotonHashTable roomSetting = PhotonNetwork.CurrentRoom.CustomProperties;

        roomSetting[CustomProperties.MAX_NEUTRALS] = maxNeutrals;

        PhotonNetwork.CurrentRoom.SetCustomProperties(roomSetting);
        maxNeutralText.text = maxNeutrals.ToString();
    }

    #endregion Methods
}
