using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

using PhotonHashTable = ExitGames.Client.Photon.Hashtable;

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
        killCooldownOption.InitOption("KillCooldown");
        sabotageCooldownOption.InitOption("SabotageCooldown");
        emergencyMeetingCooldownOption.InitOption("EmergencyMeetingCooldown");
        meetingTimeOption.InitOption("MeetingTime");
        voteTimeOption.InitOption("VoteTime");
    }

    #endregion Methods
}
