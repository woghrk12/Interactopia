using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class TimesOption : MonoBehaviour
{
    #region Variables

    private int timesValue = 0;
    private string optionKey = string.Empty;

    [SerializeField] private int stepValue = 0;
    [SerializeField] private int maxValue = 0;
    [SerializeField] private int minValue = 0;

    [SerializeField] private Button plusBtn = null;
    [SerializeField] private Button minusBtn = null;
    [SerializeField] private Text valueText = null;

    #endregion Variables

    #region Properties

    public int TimesValue
    {
        private set
        {
            timesValue = value;

            valueText.text = timesValue.ToString();
            PhotonNetwork.CurrentRoom.CustomProperties[optionKey] = timesValue;
        }
        get => timesValue;
    }

    #endregion Properties

    #region Methods

    public void InitOption(string key)
    {
        optionKey = key;

        timesValue = (int)PhotonNetwork.CurrentRoom.CustomProperties[optionKey];
        valueText.text = timesValue.ToString();

        plusBtn.onClick.AddListener(OnClickPlusBtn);
        minusBtn.onClick.AddListener(OnClickMinusBtn);

        if (timesValue >= maxValue) { plusBtn.interactable = false; }
        if (timesValue <= minValue) { minusBtn.interactable = false; }
    }

    public void OnClickPlusBtn()
    {
        TimesValue += stepValue;

        if (timesValue >= maxValue) { plusBtn.interactable = false; }
        if (!minusBtn.interactable) { minusBtn.interactable = true; }
    }

    public void OnClickMinusBtn()
    {
        TimesValue -= stepValue;

        if (timesValue <= minValue) { minusBtn.interactable = false; }
        if (!plusBtn.interactable) { plusBtn.interactable = true; }
    }

    #endregion Methods
}
