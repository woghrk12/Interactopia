using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HostRuleSettingPanel : UIPanel
{
    private enum EGroup { NUMOFPLAYER, PLAYRULE, ROLES, TIMES }

    #region Variables
    
    private InGameUI inGameUI = null;

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

        numOfPlayerGroup.InitGroup();
        playRuleGroup.InitGroup();
        timesGroup.InitGroup();

        numOfPlayerGroup.gameObject.SetActive(true);
        playRuleGroup.gameObject.SetActive(false);
        rolesGroup.SetActive(false);
        timesGroup.gameObject.SetActive(false);
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

    #endregion Methods
}
