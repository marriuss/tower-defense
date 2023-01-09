public class Balance
{
    private const int StartMoney = 0;

    private int _money;

    public bool HasEnoughMoney(int value) => _money >= value;

    public Balance() : this(StartMoney) { }

    public Balance(int money)
    {
        _money = money;
    }

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
