using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

using PhotonHashTable = ExitGames.Client.Photon.Hashtable;

public class HostRuleSettingPanel : UIPanel
{
    private enum EGroup { NUMOFPLAYER, PLAYRULE, ROLES, TIMES }

    #region Variables

    private InGameUI inGameUI = null;

    private PhotonHashTable roomSetting = null;

    [SerializeField] private Image backgroundImg = null;
    [SerializeField] private Button closeBtn = null;

    [SerializeField] private Button numOfPlayerBtn = null;
    [SerializeField] private Button playRuleBtn = null;
    [SerializeField] private Button rolesBtn = null;
    [SerializeField] private Button timesBtn = null;

    [SerializeField] private NumOfPlayerGroup numOfPlayerGroup = null;
    [SerializeField] private PlayRuleGroup playRuleGroup = null;
    [SerializeField] private GameObject rolesGroup = null;
    [SerializeField] private TimesGroup timesGroup = null;

    [SerializeField] private Button cancelBtn = null;
    [SerializeField] private Button confirmBtn = null;

    #endregion Variables

    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        inGameUI = uiBase as InGameUI;

        backgroundImg.GetComponent<Button>().onClick.AddListener(OnClickCloseBtn);
        closeBtn.onClick.AddListener(OnClickCloseBtn);

        numOfPlayerBtn.onClick.AddListener(OnClickNumOfPlayerBtn);
        playRuleBtn.onClick.AddListener(OnClickPlayRuleBtn);
        rolesBtn.onClick.AddListener(OnClickRolesBtn);
        timesBtn.onClick.AddListener(OnClickTimesBtn);

        cancelBtn.onClick.AddListener(OnClickCancelBtn);
        confirmBtn.onClick.AddListener(OnClickConfirmBtn);

        numOfPlayerGroup.gameObject.SetActive(true);
        playRuleGroup.gameObject.SetActive(false);
        rolesGroup.SetActive(false);
        timesGroup.gameObject.SetActive(false);

        OnActive += (() =>
        {
            roomSetting = PhotonNetwork.CurrentRoom.CustomProperties;

            numOfPlayerGroup.InitGroup(roomSetting);
            playRuleGroup.InitGroup(roomSetting);
            timesGroup.InitGroup(roomSetting);
        });
        OnDeactive += (() =>
        {
            roomSetting = null;
        });
    }

    public void OnClickCloseBtn() => inGameUI.TurnOffPanel(EInGamePanel.HOSTRULESETTING);

    public void OnClickNumOfPlayerBtn()
    {
        numOfPlayerGroup.gameObject.SetActive(true);

        playRuleGroup.gameObject.SetActive(false);
        rolesGroup.SetActive(false);
        timesGroup.gameObject.SetActive(false);
    }

    public void OnClickPlayRuleBtn()
    {
        playRuleGroup.gameObject.SetActive(true);

        numOfPlayerGroup.gameObject.SetActive(false);
        rolesGroup.SetActive(false);
        timesGroup.gameObject.SetActive(false);
    }

    public void OnClickRolesBtn()
    {
        rolesGroup.SetActive(true);

        numOfPlayerGroup.gameObject.SetActive(false);
        playRuleGroup.gameObject.SetActive(false);
        timesGroup.gameObject.SetActive(false);
    }

    public void OnClickTimesBtn()
    {
        timesGroup.gameObject.SetActive(true);

        numOfPlayerGroup.gameObject.SetActive(false);
        playRuleGroup.gameObject.SetActive(false);
        rolesGroup.SetActive(false);
    }

    public void OnClickCancelBtn()
    {
        inGameUI.TurnOffPanel(EInGamePanel.HOSTRULESETTING);
    }

    public void OnClickConfirmBtn()
    {
        PhotonHashTable numOfPlayerSetting = numOfPlayerGroup.OptionSetting;
        foreach (var item in numOfPlayerSetting)
        {
            if (!roomSetting.ContainsKey(item.Key))
            {
                roomSetting.Add(item.Key, item.Value);
                continue;
            }

            roomSetting[item.Key] = item.Value;
        }

        PhotonHashTable playRuleSetting = playRuleGroup.OptionSetting;
        foreach (var item in playRuleSetting)
        {
            if (!roomSetting.ContainsKey(item.Key))
            {
                roomSetting.Add(item.Key, item.Value);
                continue;
            }

            roomSetting[item.Key] = item.Value;
        }

        PhotonHashTable timesSetting = timesGroup.OptionSetting;
        foreach (var item in timesSetting)
        {
            if (!roomSetting.ContainsKey(item.Key))
            {
                roomSetting.Add(item.Key, item.Value);
                continue;
            }

            roomSetting[item.Key] = item.Value;
        }

        PhotonNetwork.CurrentRoom.SetCustomProperties(roomSetting);

        inGameUI.TurnOffPanel(EInGamePanel.HOSTRULESETTING);
    }

    #endregion Methods
}
