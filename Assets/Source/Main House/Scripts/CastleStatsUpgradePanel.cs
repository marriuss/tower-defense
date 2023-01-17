using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CastleStatsUpgradePanel : Panel
{
    [Space(10)]
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _damageText;
    [SerializeField] private TMP_Text _populationText;
    [SerializeField] private TMP_Text _guardHealthText;
    [SerializeField] private TMP_Text _guardDamageText;

    [Space(10)]
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private TMP_Text _upgradeButtonText;

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
        _upgradeButtonText.text = $"Upgrade ({_castleUpgrade.Castle.UpgradeCost})";
    }
}
