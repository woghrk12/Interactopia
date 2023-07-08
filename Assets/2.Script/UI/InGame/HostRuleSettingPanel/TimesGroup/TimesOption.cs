using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

using PhotonHashTable = ExitGames.Client.Photon.Hashtable;

public class TimesOption : MonoBehaviour
{
    #region Variables

    private string optionKey = string.Empty;

    [SerializeField] private int stepValue = 0;
    [SerializeField] private int maxValue = 0;
    [SerializeField] private int minValue = 0;

    [SerializeField] private Button plusBtn = null;
    [SerializeField] private Button minusBtn = null;
    [SerializeField] private Text valueText = null;

    #endregion Variables

    #region Properties

    public int TimesValue => (int)PhotonNetwork.CurrentRoom.CustomProperties[optionKey];

    #endregion Properties

    #region Methods

    public void InitOption(string key)
    {
        optionKey = key;

        int timesValue = (int)PhotonNetwork.CurrentRoom.CustomProperties[optionKey];
        valueText.text = timesValue.ToString();

        plusBtn.onClick.AddListener(OnClickPlusBtn);
        minusBtn.onClick.AddListener(OnClickMinusBtn);

        if (timesValue >= maxValue) { plusBtn.interactable = false; }
        if (timesValue <= minValue) { minusBtn.interactable = false; }
    }

    public void OnClickPlusBtn()
    {
        PhotonHashTable roomSetting = PhotonNetwork.CurrentRoom.CustomProperties;
        int timesValue = (int)roomSetting[optionKey];

        timesValue += stepValue;

        PhotonNetwork.CurrentRoom.SetCustomProperties(roomSetting);

        if (timesValue >= maxValue) { plusBtn.interactable = false; }
        if (!minusBtn.interactable) { minusBtn.interactable = true; }
    }

    public void OnClickMinusBtn()
    {
        PhotonHashTable roomSetting = PhotonNetwork.CurrentRoom.CustomProperties;
        int timesValue = (int)roomSetting[optionKey];

        timesValue += stepValue;

        PhotonNetwork.CurrentRoom.SetCustomProperties(roomSetting);

        if (timesValue <= minValue) { minusBtn.interactable = false; }
        if (!plusBtn.interactable) { plusBtn.interactable = true; }
    }

    #endregion Methods
}
