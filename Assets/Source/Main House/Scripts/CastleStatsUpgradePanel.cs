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
        UpdateInfo(_castleUpgrade.Castle);
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

    private void OnCloseButtonClick()
    {
        HidePanel();
    }
}
