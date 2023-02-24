using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CastleStatsUpgradePanel : Panel
{
    [Space(10)]
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _towersAmountText;
    [SerializeField] private TMP_Text _towerHealthText;

    [Space(10)]
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private TMP_Text _upgradeCostText;

    [Space(10)]
    [SerializeField] private CastleUpgrade _castleUpgrade;

    protected override void OnEnabled()
    {
        _upgradeButton.onClick.AddListener(OnUpgradeButtonClick);
        _castleUpgrade.DataUpdated += OnUpgradeDataUpdated;

        UpdateInfo(_castleUpgrade.Castle);
        UpdateUpgradeButton();
    }

    protected override void OnDisabled()
    {
        _upgradeButton.onClick.RemoveListener(OnUpgradeButtonClick);
        _castleUpgrade.DataUpdated -= OnUpgradeDataUpdated;
    }

    public void UpdateInfo(Castle castleStats)
    {
        _levelText.text = castleStats.Level.ToString();
        _towersAmountText.text = castleStats.TotalTowersAmount.ToString();
        _towerHealthText.text = string.Format("{0:f0}", castleStats.TotalTowerHealth);
    }

    private void OnUpgradeButtonClick()
    {
        _castleUpgrade.TryUpgrade();
        UpdateInfo(_castleUpgrade.Castle);
        UpdateUpgradeButton();
    }

    private void UpdateUpgradeButton()
    {
        _upgradeButton.interactable = _castleUpgrade.CanUpgrade;
        _upgradeCostText.text = _castleUpgrade.Castle.UpgradeCost.ToString();
    }

    private void OnUpgradeDataUpdated()
    {
        UpdateInfo(_castleUpgrade.Castle);
    }
}
