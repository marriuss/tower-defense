using UnityEngine;

public class CastleButton : WorkButton
{
    [SerializeField] private CastleStatsUpgradePanel _mainHouseStatsPanel;

    protected override void OnButtonClick()
    {
        _mainHouseStatsPanel.ShowPanel();
    }
}
