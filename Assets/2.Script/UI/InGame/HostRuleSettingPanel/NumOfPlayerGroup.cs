using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

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

        int maxPlayers = PhotonNetwork.CurrentRoom.MaxPlayers;
        maxPlayerSlider.value = maxPlayers;
        maxPlayerText.text = maxPlayers.ToString();

        int maxMafias = (int)PhotonNetwork.CurrentRoom.CustomProperties["MaxMafias"];
        maxMafiaSlider.value = maxMafias;
        maxMafiaText.text = maxMafias.ToString();

        int maxNeutrals = (int)PhotonNetwork.CurrentRoom.CustomProperties["MaxNeutrals"];
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
        PhotonNetwork.CurrentRoom.CustomProperties["MaxMafias"] = maxMafias;
        maxMafiaText.text = maxMafias.ToString();
    }

    public void OnMaxNeutralsChanged(float value)
    {
        int maxNeutrals = (int)value;
        PhotonNetwork.CurrentRoom.CustomProperties["MaxNeutrals"] = maxNeutrals;
        maxNeutralText.text = maxNeutrals.ToString();
    }

    #endregion Methods
}
