using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using DG.Tweening;

using PhotonHashTable = ExitGames.Client.Photon.Hashtable;

public enum ESight { NARROW, MIDDLE, WIDE }
public enum EMoveSpeed { SLOW, MIDDLE, FAST }

public class GuestRuleSettingPanel : UIPanel
{
    #region Variables

    private InGameUI inGameUI = null;

    [SerializeField] private Image backgroundImg = null;
    [SerializeField] private Button closeBtn = null;

    [SerializeField] private Text maxMafiaText = null;
    [SerializeField] private Text maxNeutralText = null;
    [SerializeField] private Text shortDistanceVoiceText = null;
    [SerializeField] private Text randomStartPointText = null;
    [SerializeField] private Text hideEmissionInfoText = null;
    [SerializeField] private Text blindMafiaModeText = null;
    [SerializeField] private Text openVoteResultText = null;
    [SerializeField] private Text normalSightText = null;
    [SerializeField] private Text mafiaSightText = null;
    [SerializeField] private Text neutralSightText = null;
    [SerializeField] private Text moveSpeedText = null;
    [SerializeField] private Text killCooldownText = null;
    [SerializeField] private Text sabotageCooldownText = null;
    [SerializeField] private Text emergencyMeetingCooldownText = null;
    [SerializeField] private Text meetingTimeText = null;
    [SerializeField] private Text voteTimeText = null;

    #endregion Variables

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        inGameUI = uiBase as InGameUI;

        backgroundImg.GetComponent<Button>().onClick.AddListener(OnClickCloseBtn);
        closeBtn.onClick.AddListener(OnClickCloseBtn);

        OnActive += (() => SetOptionText(PhotonNetwork.CurrentRoom.CustomProperties));
    }

    private void SetOptionText(PhotonHashTable roomProperties)
    {
        maxMafiaText.text = ((int)roomProperties[CustomProperties.MAX_MAFIAS]).ToString();
        maxNeutralText.text = ((int)roomProperties[CustomProperties.MAX_NEUTRALS]).ToString();

        shortDistanceVoiceText.text = (bool)roomProperties[CustomProperties.SHORT_DISTANCE_VOICE] ? "On" : "Off";
        randomStartPointText.text = (bool)roomProperties[CustomProperties.RANDOM_START_POINT] ? "On" : "Off";
        hideEmissionInfoText.text = (bool)roomProperties[CustomProperties.HIDE_EMISSION_INFO] ? "On" : "Off";
        blindMafiaModeText.text = (bool)roomProperties[CustomProperties.BLIND_MAFIA_MODE] ? "On" : "Off";
        openVoteResultText.text = (bool)roomProperties[CustomProperties.OPEN_VOTE_RESULT] ? "On" : "Off";

        normalSightText.text = ((ESight)roomProperties[CustomProperties.NORMAL_SIGHT]).ToString();
        mafiaSightText.text = ((ESight)roomProperties[CustomProperties.MAFIA_SIGHT]).ToString();
        neutralSightText.text = ((ESight)roomProperties[CustomProperties.NEUTRAL_SIGHT]).ToString();
        moveSpeedText.text = ((EMoveSpeed)roomProperties[CustomProperties.MOVE_SPEED]).ToString();

        killCooldownText.text = ((int)roomProperties[CustomProperties.KILL_COOLDOWN]).ToString();
        sabotageCooldownText.text = ((int)roomProperties[CustomProperties.SABOTAGE_COOLDOWN]).ToString();
        emergencyMeetingCooldownText.text = ((int)roomProperties[CustomProperties.EMERGENCY_MEETING_COOLDOWN]).ToString();
        meetingTimeText.text = ((int)roomProperties[CustomProperties.MEETING_TIME]).ToString();
        voteTimeText.text = ((int)roomProperties[CustomProperties.VOTE_TIME]).ToString();
    }

    #endregion Methods

    #region Event Methods

    public override Sequence ActiveAnimation()
    {
        return DOTween.Sequence();
    }

    public override Sequence DeactiveAnimation()
    {
        return DOTween.Sequence();
    }

    #endregion Event Methods

    #region Event Methods

    public void OnClickCloseBtn() => inGameUI.ClosePanel(EInGamePanel.GUESTRULESETTING);

    #endregion Event Methods

    #region Photon Events

    public override void OnRoomPropertiesUpdate(PhotonHashTable propertiesThatChanged)
        => SetOptionText(propertiesThatChanged);

    #endregion Photon Events
}
