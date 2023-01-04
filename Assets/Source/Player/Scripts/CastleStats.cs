public class CastleStats
{
    private const int BaseHealth = 50;

    public int Health;
    public int Level;

    public CastleStats()
    {
        Level = 1;
        Health = 1;
    }

    public CastleStats(int level)
    {
        Level = 1;
        Health = CalculateHealth(level);
    }

    private int CalculateHealth(int level)
    {
        // TODO
        return BaseHealth;
    }
}
