using UnityEngine;

using PhotonHashTable = ExitGames.Client.Photon.Hashtable;

public class TimesGroup : MonoBehaviour
{
    #region Variables

    [SerializeField] private ButtonOption killCooldownOption = null;
    [SerializeField] private ButtonOption sabotageCooldownOption = null;
    [SerializeField] private ButtonOption emergencyMeetingCooldownOption = null;
    [SerializeField] private ButtonOption meetingTimeOption = null;
    [SerializeField] private ButtonOption voteTimeOption = null;

    #endregion Variables

    #region Properties

    public PhotonHashTable OptionSetting
    {
        get
        {
            PhotonHashTable optionSetting = new();

            optionSetting.Add(CustomProperties.KILL_COOLDOWN, killCooldownOption.OptionValue);
            optionSetting.Add(CustomProperties.SABOTAGE_COOLDOWN, sabotageCooldownOption.OptionValue);
            optionSetting.Add(CustomProperties.EMERGENCY_MEETING_COOLDOWN, emergencyMeetingCooldownOption.OptionValue);
            optionSetting.Add(CustomProperties.MEETING_TIME, meetingTimeOption.OptionValue);
            optionSetting.Add(CustomProperties.VOTE_TIME, voteTimeOption.OptionValue);

            return optionSetting;
        }
    }

    #endregion Properties

    #region Methods

    public void InitGroup(PhotonHashTable roomSetting)
    {
        killCooldownOption.InitOption((int)roomSetting[CustomProperties.KILL_COOLDOWN]);
        sabotageCooldownOption.InitOption((int)roomSetting[CustomProperties.SABOTAGE_COOLDOWN]);
        emergencyMeetingCooldownOption.InitOption((int)roomSetting[CustomProperties.EMERGENCY_MEETING_COOLDOWN]);
        meetingTimeOption.InitOption((int)roomSetting[CustomProperties.MEETING_TIME]);
        voteTimeOption.InitOption((int)roomSetting[CustomProperties.VOTE_TIME]);
    }
    
    #endregion Methods
}
