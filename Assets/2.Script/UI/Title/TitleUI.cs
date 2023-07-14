public enum ETitleUIPanel { NONE = -1, START, LOBBY, CREATEROOM, PUBLICJOIN, PRIVATEJOIN, SETTING, AUTH, LOADING, FADE, END }

public class TitleUI : UIBase
{
    #region Methods

    public override void InitBase()
    {
        base.InitBase();

        PopupPanel(ETitleUIPanel.START);
    }

    public UIPanel GetPanel(ETitleUIPanel panel) { return uiPanelList[(int)panel]; }

    public void OpenPanel(ETitleUIPanel openPanel, ETitleUIPanel closePanel)
        => OpenPanel((int)openPanel, (int)closePanel);

    public void ClosePanel(ETitleUIPanel panel) => ClosePanel((int)panel);

    public void PopupPanel(ETitleUIPanel panel) => PopupPanel((int)panel);

    #endregion Methods
}
