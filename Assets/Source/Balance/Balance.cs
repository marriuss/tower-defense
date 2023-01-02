using UnityEngine;

public class Balance : MonoBehaviour
{
    [SerializeField] private BalanceProgress _balanceProgress;

    private int _money;

    public int Money => _money;

    private void Start()
    {
        ApplyProgress();
    }

    private void ApplyProgress()
    {
        _money = _balanceProgress.GetBalance();
    }

    public void AddMoney(int value)
    {
        if (value <= 0)
        {
            return;
        }

        _money += value;
        _balanceProgress.SetBalance(_money);
    }

    public bool TrySpend(int value)
    {
        if (_money < value)
        {
            return false;
        }

        _money -= value;
        _balanceProgress.SetBalance(_money);
        return true;
    }
}
