using UnityEngine;

public class MainHouseButton : WorkButton
{
    [SerializeField] private CastleStatsUpgradePanel _mainHouseStatsPanel;

    protected override void OnButtonClick()
    {
        _mainHouseStatsPanel.ShowPanel();
    }
}
