using UnityEngine;

public class CastleUpgrade : MonoBehaviour
{
    [SerializeField] private ProgressLoader _progressLoader;

    private CastleStats _castleStats;
    private Balance _balance;

    public bool CanUpgrade => _balance.HasEnoughMoney(_castleStats.UpgradeCost);
    public CastleStats CastleStats => _castleStats;

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
        _castleStats = new CastleStats(playerProgress.CastleLevel);
        _balance = new Balance(playerProgress.Balance);
    }
}
