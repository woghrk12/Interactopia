using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class CreateRoomPanel : UIPanel
{
    #region Variables

    private TitleUI titleUI = null;

    [SerializeField] private Button createBtn = null;
    [SerializeField] private Button cancelBtn = null;

    #endregion Variables
 
    #region Methods

    public override void InitPanel(UIBase uiBase)
    {
        titleUI = uiBase as TitleUI;

        createBtn.onClick.AddListener(OnClickCreateBtn);
        cancelBtn.onClick.AddListener(OnClickCancelBtn);
    }

    public void OnClickCreateBtn()
    {
        RoomOption roomOption = new RoomOption("test", new RoomOptions { MaxPlayers = 16 });

        NetworkManager.CreateRooom(roomOption);
    }

    public void OnClickCancelBtn() { titleUI.TurnOnPanel(ETitleUIPanel.LOBBY); }

    public override IEnumerator OnActivePanel()
    {
        // TODO : implement panel effects
        yield return null;
    }

    public override IEnumerator OnDeactivePanel()
    {
        // TODO : implement panel effects
        yield return null;
    }

    #endregion Methods
}
