using UnityEngine;
 
public class CastleUpgrade : MonoBehaviour
{
    [SerializeField] private ProgressLoader _progressLoader;

    private Castle _castleStats;
    private Balance _balance;

    public bool CanUpgrade => _balance.HasEnoughMoney(_castleStats.UpgradeCost);
    public Castle CastleStats => _castleStats;

    private void OnEnable()
    {
        _progressLoader.ProgressLoaded += OnProgressLoaded;
    }

    private void OnDisable()
    {
        _progressLoader.ProgressLoaded -= OnProgressLoaded;
    }

    public void TryUpgrade()
    {
        if (CanUpgrade == false)
        {
            return;
        }

        _castleStats.Upgrade();
        _balance.TrySpend(_castleStats.UpgradeCost);
    }

    private void OnProgressLoaded(PlayerProgress playerProgress)
    {
        _castleStats = playerProgress.CastleProgress;
        _balance = playerProgress.Balance;
    }
}
