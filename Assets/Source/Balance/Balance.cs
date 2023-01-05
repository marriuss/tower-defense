using UnityEngine;

public class Balance
{
    private int _money;

    public int Money => _money;

    public bool HasEnoughMoney(int value) => _money >= value;

    public void AddMoney(int value)
    {
        if (value <= 0)
        {
            return;
        }

        _money += value;
    }

    public bool TrySpend(int value)
    {
        if (_money < value)
        {
            return false;
        }

        _money -= value;
        return true;
    }
}
