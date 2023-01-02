using UnityEngine;

public class Balance : MonoBehaviour
{
    [SerializeField] private ProgressLoader _progressLoader;

    private int _money;

    public int Money => _money;

    private void OnEnable()
    {
        _progressLoader.ProgressLoaded += OnProgressLoaded;
    }

    private void OnDisable()
    {
        _progressLoader.ProgressLoaded -= OnProgressLoaded;
    }

    private void OnProgressLoaded(PlayerProgress progress)
    {
        _money = progress.Balance;
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
