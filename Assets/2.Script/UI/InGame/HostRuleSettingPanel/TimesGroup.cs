using UnityEngine;

public class TimesGroup : MonoBehaviour
{
    #region Variables

    [SerializeField] private TimesOption killCooldownOption = null;
    [SerializeField] private TimesOption sabotageCooldownOption = null;
    [SerializeField] private TimesOption emergencyMeetingCooldownOption = null;
    [SerializeField] private TimesOption meetingTimeOption = null;
    [SerializeField] private TimesOption voteTimeOption = null;

    #endregion Variables

    #region Methods

    public void InitGroup()
    {
        killCooldownOption.InitOption(CustomProperties.KILL_COOLDOWN);
        sabotageCooldownOption.InitOption(CustomProperties.SABOTAGE_COOLDOWN);
        emergencyMeetingCooldownOption.InitOption(CustomProperties.EMERGENCY_MEETING_COOLDOWN);
        meetingTimeOption.InitOption(CustomProperties.MEETING_TIME);
        voteTimeOption.InitOption(CustomProperties.VOTE_TIME);
    }

    #endregion Methods
}
