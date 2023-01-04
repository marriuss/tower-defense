using UnityEngine;

public class MainHouse : WorkButton
{
    [SerializeField] private MainHouseStatsPanel _mainHouseStatsPanel;
    [SerializeField] private ProgressLoader _progressLoader;

    private int _level;
    private int _health;
    private int _damage;
    private int _population;

    private int _guardHealth;
    private int _guardDamage;

    public int Level => _level;
    public int Health => _health;
    public int Damage => _damage;
    public int Population => _population;
    public int GuardHealth => _guardHealth;
    public int GuardDamage => _guardDamage;

    private void OnEnable()
    {
        _progressLoader.ProgressLoaded += ApplyProgress;
    }

    private void OnDisable()
    {
        _progressLoader.ProgressLoaded -= ApplyProgress;
    }

    private void ApplyProgress(PlayerProgress progress)
    {
        _level = progress.MainHouseProgress.Level;
        _health = progress.MainHouseProgress.Health;
        _damage = progress.MainHouseProgress.Damage;
        _population = progress.MainHouseProgress.Population;
        _guardHealth = progress.MainHouseProgress.GuardHealth;
        _guardDamage = progress.MainHouseProgress.GuardDamage;
    }

    protected override void OnButtonClick()
    {
        _mainHouseStatsPanel.ShowPanel();
    }
}
