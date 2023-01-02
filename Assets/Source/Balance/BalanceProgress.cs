using UnityEngine;

public class BalanceProgress : MonoBehaviour
{
    private Saver _saver = Saver.GetSaver("BalanceProgress");

    public void SetBalance(int money)
    {
        _saver.Save(money.ToString());
    }

    public int GetBalance()
    {
        if (int.TryParse(_saver.Load(), out int money))
        {
            return money;
        }

        return 0;
    }
}
