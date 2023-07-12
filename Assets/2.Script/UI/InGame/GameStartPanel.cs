using DG.Tweening;

public class GameStartPanel : UIPanel
{
    #region Variables

    private InGameUI inGameUI = null;

    #endregion Variables

    #region Methods

    // TODO : add condition to check player's camp

    public override void InitPanel(UIBase uiBase)
    {
        inGameUI = uiBase as InGameUI;
    }

    #endregion Methods

    #region Override Methods

    public override Sequence ActiveAnimation()
    {
        return DOTween.Sequence();
    }

    public override Sequence DeactiveAnimation()
    {
        return DOTween.Sequence();
    }

    #endregion Override Methods
}
