using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainHouseStatsPanel : MonoBehaviour
{
    [SerializeField] private MainHouse _mainHouse;
    [Space(10)]
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _damageText;
    [SerializeField] private TMP_Text _populationText;
    [SerializeField] private TMP_Text _guardHealthText;
    [SerializeField] private TMP_Text _guardDamageText;
    [Space(10)]
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Button _closeButton;

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
        UpdateInfo();
    }

    public void HidePanel()
    {
        gameObject.SetActive(false);
    }

    public void UpdateInfo()
    {
        _levelText.text = _mainHouse.Level.ToString();
        _healthText.text = _mainHouse.Health.ToString();
        _damageText.text = _mainHouse.Damage.ToString();
        _populationText.text = _mainHouse.Population.ToString();
        _guardHealthText.text = _mainHouse.GuardHealth.ToString();
        _guardDamageText.text = _mainHouse.GuardDamage.ToString();
    }

    private void OnUpgradeButtonClick()
    {

    }

    private void OnCloseButtonClick()
    {
        HidePanel();
    }
}
