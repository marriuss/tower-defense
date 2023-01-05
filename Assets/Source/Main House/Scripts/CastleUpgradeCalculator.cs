using UnityEngine;

public class CastleUpgradeCalculator
{
    private const int StartCost = 10;
    private const int StartHealth = 5;
    private const int StartDamage = 10;
    private const int StartPopulation = 100;
    private const int StartGuardHealth = 10;
    private const int StartGuardDamage = 10;

    private const float CostMultiplier = 5f;
    private const float HealthMultiplier = 5f;
    private const float DamageMultiplier = 3f;
    private const float PopulationMultiplier = 25f;
    private const float GuardHealthMultiplier = 5f;
    private const float GuardDamageMultiplier = 5f;

    public int GetUpgradeCostByLevel(int level)
    {
        return GetReccurentValue(StartCost, CostMultiplier, level);
    }

    public int GetHealthByLevel(int level)
    {
        return GetReccurentValue(StartHealth, HealthMultiplier, level);
    }

    public int GetDamageByLevel(int level)
    {
        return GetReccurentValue(StartDamage, DamageMultiplier, level);
    }

    public int GetPopulationByLevel(int level)
    {
        return GetReccurentValue(StartPopulation, PopulationMultiplier, level);
    }

    public int GetGuardHealthByLevel(int level)
    {
        return GetReccurentValue(StartGuardHealth, GuardHealthMultiplier, level);
    }

    public int GetGuardDamageByLevel(int level)
    {
        return GetReccurentValue(StartGuardDamage, GuardDamageMultiplier, level);
    }

    private int GetReccurentValue(int startValue, float multiplier, int stepsCount)
    {
        int result = 0;

        for (int i = 0; i < stepsCount; i++)
        {
            result += (int)Mathf.Floor(i * multiplier + startValue);
        }

        return result;
    }
}
