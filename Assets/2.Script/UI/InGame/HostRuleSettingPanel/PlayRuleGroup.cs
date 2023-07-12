using UnityEngine;
using UnityEngine.UI;

using PhotonHashTable = ExitGames.Client.Photon.Hashtable;

public class PlayRuleGroup : MonoBehaviour
{
    #region Variables

    [SerializeField] private ToggleOption shortDistanceVoiceOption = null;
    [SerializeField] private ToggleOption randomStartPointOption = null;
    [SerializeField] private ToggleOption hideEmissionInfoOption = null;
    [SerializeField] private ToggleOption blindMafiaModeOption = null;
    [SerializeField] private ToggleOption openVoteResultOption = null;

    [SerializeField] private DropdownOption normalSightOption = null;
    [SerializeField] private DropdownOption mafiaSightOption = null;
    [SerializeField] private DropdownOption neutralSightOption = null;
    [SerializeField] private DropdownOption moveSpeedOption = null;

    #endregion Variables

    #region Properties

    public PhotonHashTable OptionSetting
    {
        get
        {
            PhotonHashTable optionSetting = new();

            optionSetting.Add(CustomProperties.SHORT_DISTANCE_VOICE, shortDistanceVoiceOption.OptionValue);
            optionSetting.Add(CustomProperties.RANDOM_START_POINT, randomStartPointOption.OptionValue);
            optionSetting.Add(CustomProperties.HIDE_EMISSION_INFO, hideEmissionInfoOption.OptionValue);
            optionSetting.Add(CustomProperties.BLIND_MAFIA_MODE, blindMafiaModeOption.OptionValue);
            optionSetting.Add(CustomProperties.OPEN_VOTE_RESULT, openVoteResultOption.OptionValue);

            optionSetting.Add(CustomProperties.NORMAL_SIGHT, normalSightOption.OptionValue);
            optionSetting.Add(CustomProperties.MAFIA_SIGHT, mafiaSightOption.OptionValue);
            optionSetting.Add(CustomProperties.NEUTRAL_SIGHT, neutralSightOption.OptionValue);
            optionSetting.Add(CustomProperties.MOVE_SPEED, moveSpeedOption.OptionValue);

            return optionSetting;
        }
    }

    #endregion Properties

    #region Methods

    public void InitGroup(PhotonHashTable roomSetting)
    {
        shortDistanceVoiceOption.InitOption((bool)roomSetting[CustomProperties.SHORT_DISTANCE_VOICE]);
        randomStartPointOption.InitOption((bool)roomSetting[CustomProperties.RANDOM_START_POINT]);
        hideEmissionInfoOption.InitOption((bool)roomSetting[CustomProperties.HIDE_EMISSION_INFO]);
        blindMafiaModeOption.InitOption((bool)roomSetting[CustomProperties.BLIND_MAFIA_MODE]);
        openVoteResultOption.InitOption((bool)roomSetting[CustomProperties.OPEN_VOTE_RESULT]);

        normalSightOption.InitOption((int)roomSetting[CustomProperties.NORMAL_SIGHT]);
        mafiaSightOption.InitOption((int)roomSetting[CustomProperties.MAFIA_SIGHT]);
        neutralSightOption.InitOption((int)roomSetting[CustomProperties.NEUTRAL_SIGHT]);
        moveSpeedOption.InitOption((int)roomSetting[CustomProperties.MOVE_SPEED]);
    }

    #endregion Methods
}
