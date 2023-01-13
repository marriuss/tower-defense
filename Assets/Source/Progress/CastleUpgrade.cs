using UnityEngine;
 
public class CastleUpgrade : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Balance _balance;

    public Castle Castle { get; private set; }
    public bool CanUpgrade => _balance.HasEnoughMoney(Castle.UpgradeCost);

    private void Awake()
    {
        Castle = _player.Castle;
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
