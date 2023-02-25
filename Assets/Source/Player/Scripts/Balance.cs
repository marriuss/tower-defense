using UnityEngine.Events;
using System;

public class Balance
{
    public const int StartMoney = 0;

    public int Money { get; private set; }
    public bool HasEnoughMoney(int value) => Money >= value;

    public event UnityAction<int> MoneyCountChanged;

    public Balance() : this(StartMoney) { }

    public Balance(int money)
    {
        Initialize(money);
    }

    public void Initialize(int money)
    {
        if (money < StartMoney)
            throw new ArgumentException();

        AddMoney(money);
    }

    public void AddMoney(int value)
    {
        if (value < 0)
            throw new NegativeArgumentException();

        ChangeMoneyValue(+value);
    }

    public bool TrySpend(int value)
    {
        if (value < 0)
            throw new NegativeArgumentException();

        if (Money < value)
            return false;

        ChangeMoneyValue(-value);
        return true;
    }

    private void ChangeMoneyValue(int difference)
    {
        if (difference == 0)
            return;

        Money += difference;
        MoneyCountChanged?.Invoke(Money);
    }
}
