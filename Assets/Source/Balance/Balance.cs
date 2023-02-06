using UnityEngine.Events;

public class Balance
{
    private const int StartMoney = 0;

    public int Money { get; private set; }

    public Balance() : this(StartMoney) { }

    public Balance(int money)
    {
        Money = money;
    }

    public event UnityAction<int> MoneyCountChanged;

    public bool HasEnoughMoney(int value) => Money >= value;

    public void AddMoney(int value)
    {
        if (value <= 0)
        {
            return;
        }

        Money += value;
        MoneyCountChanged?.Invoke(Money);
    }

    public bool TrySpend(int value)
    {
        if (Money < value)
        {
            return false;
        }

        Money -= value;
        MoneyCountChanged?.Invoke(Money);
        return true;
    }
}
