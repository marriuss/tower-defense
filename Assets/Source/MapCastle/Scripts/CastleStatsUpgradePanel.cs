using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CastleStatsUpgradePanel : Panel
{
    [Space(10)]
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _additionalTowersText;
    [SerializeField] private TMP_Text _towerHealthFractionText;

    [Space(10)]
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private TMP_Text _upgradeCostText;

    [Space(10)]
    [SerializeField] private CastleUpgrade _castleUpgrade;

    protected override void OnEnabled()
    {
        _upgradeButton.onClick.AddListener(OnUpgradeButtonClick);
    }

    protected override void OnDisabled()
    {
        _upgradeButton.onClick.RemoveListener(OnUpgradeButtonClick);
    }

    public void ShowPanel()
    {
        gameObject.SetActive(true);
        UpdateInfo(_castleUpgrade.Castle);
        UpdateUpgradeButton();
    }

    public void UpdateInfo(Castle castleStats)
    {
        _levelText.text = castleStats.Level.ToString();
        _healthText.text = castleStats.Health.ToString();
        _additionalTowersText.text = castleStats.AdditionalTowersAmount.ToString();
        _towerHealthFractionText.text = string.Format("{0:f2}", castleStats.TowerHealthFraction);
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
}
