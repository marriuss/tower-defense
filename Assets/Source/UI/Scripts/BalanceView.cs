using TMPro;
using UnityEngine;

public class BalanceView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _balanceText;

    private void Start()
    {
        _player.Balance.MoneyCountChanged += OnMoneyCountChanged;
        UpdateMoneyText(_player.Balance.Money);
    }

    private void OnDestroy()
    {
        _player.Balance.MoneyCountChanged -= OnMoneyCountChanged;
    }

    private void OnMoneyCountChanged(int money)
    {
        UpdateMoneyText(money);
    }

    private void UpdateMoneyText(int money)
    {
        _balanceText.text = money.ToString();
    }
}
