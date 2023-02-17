using UnityEngine;
 
public class CastleUpgrade : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Balance _balance;

    public Castle Castle { get; private set; }
    public bool CanUpgrade => _balance.HasEnoughMoney(Castle.UpgradeCost) && Castle.CanUpgrade;

    private void Awake()
    {
        Castle = _player.Castle;
        _balance = _player.Balance;
    }

    public void TryUpgrade()
    {
        if (CanUpgrade == false)
        {
            return;
        }

        Castle.Upgrade();
        _balance.TrySpend(Castle.UpgradeCost);
    }
}
