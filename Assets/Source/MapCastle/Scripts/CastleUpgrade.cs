using UnityEngine;
using UnityEngine.Events;

public class CastleUpgrade : MonoBehaviour
{
    public event UnityAction DataUpdated;

    [SerializeField] private Player _player;

    private Balance _balance;

    public Castle Castle { get; private set; }
    public bool CanUpgrade => _balance.HasEnoughMoney(Castle.UpgradeCost) && Castle.CanUpgrade;

    private void Awake()
    {
        Castle = _player.Castle;
        _balance = _player.Balance;
    }

    private void OnEnable()
    {
        _balance.MoneyCountChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _balance.MoneyCountChanged -= OnMoneyChanged;
    }

    public void TryUpgrade()
    {
        if (CanUpgrade == false || _balance.TrySpend(Castle.UpgradeCost) == false)
        {
            return;
        }

        Castle.Upgrade();
    }

    private void OnMoneyChanged(int money)
    {
        DataUpdated?.Invoke();
    }
}
