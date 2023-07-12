using UnityEngine;

using PhotonHashTable = ExitGames.Client.Photon.Hashtable;

public class NumOfPlayerGroup : MonoBehaviour
{
    #region Variables

    [SerializeField] private SliderOption maxMafiaOption = null;
    [SerializeField] private SliderOption maxNeutralOption = null;

    #endregion Variables

    #region Properties

    public PhotonHashTable OptionSetting
    {
        get
        {
            PhotonHashTable optionSetting = new();

            optionSetting.Add(CustomProperties.MAX_MAFIAS, maxMafiaOption.OptionValue);
            optionSetting.Add(CustomProperties.MAX_NEUTRALS, maxNeutralOption.OptionValue);

            return optionSetting;
        }
    }

    #endregion Properties

    #region Methods

    public void InitGroup(PhotonHashTable roomSetting)
    {
        maxMafiaOption.InitOption((int)roomSetting[CustomProperties.MAX_MAFIAS]);
        maxNeutralOption.InitOption((int)roomSetting[CustomProperties.MAX_NEUTRALS]);
    }

    #endregion Methods
}
