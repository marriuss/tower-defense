using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CastleStatsUpgradePanel : MonoBehaviour
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
    [SerializeField] private Button _closeButton;

    [Space(10)]
    [SerializeField] private CastleUpgrade _castleUpgrade;

    private void OnEnable()
    {
        _upgradeButton.onClick.AddListener(OnUpgradeButtonClick);
        _closeButton.onClick.AddListener(OnCloseButtonClick);
    }

    private void OnDisable()
    {
        _upgradeButton.onClick.RemoveListener(OnUpgradeButtonClick);
        _closeButton.onClick.RemoveListener(OnCloseButtonClick);
    }

    public void ShowPanel()
    {
        gameObject.SetActive(true);
        UpdateInfo(_castleUpgrade.CastleStats);
        UpdateUpgradeButton();
    }

    public void HidePanel()
    {
        gameObject.SetActive(false);
    }

    public void UpdateInfo(Castle castleStats)
    {
        _levelText.text = castleStats.Level.ToString();
        _healthText.text = castleStats.Health.ToString();
        _damageText.text = castleStats.Damage.ToString();
        _populationText.text = castleStats.Population.ToString();
        _guardHealthText.text = castleStats.GuardHealth.ToString();
        _guardDamageText.text = castleStats.GuardDamage.ToString();
    }

    private void OnUpgradeButtonClick()
    {
        _castleUpgrade.TryUpgrade();
        UpdateInfo(_castleUpgrade.CastleStats);
        UpdateUpgradeButton();
    }

    private void UpdateUpgradeButton()
    {
        _upgradeButton.interactable = _castleUpgrade.CanUpgrade;
        _upgradeButtonText.text = $"Upgrade ({_castleUpgrade.CastleStats.UpgradeCost})";
    }

    private void OnCloseButtonClick()
    {
        HidePanel();
    }
}
