using UnityEngine;

public class CastleUpgradeCalculator
{
    private const int StartCost = 20;
    private const int StartHealth = 200;
    private const int StartAdditionalTowersAmount = 0;
    private const float StartTowerHealthFraction = 0.5f;
    private const float CostMultiplier = 1.5f;
    private const float HealthMultiplier = 0.1f;
    private const float AdditionalTowersAmountMultyplier = 0.02f;
    private const float TowerHealthFractionMultyplier = 0.02f;
    private const int MaxAdditionalTowersAmount = 5;

    public int GetUpgradeCostByLevel(int level)
    {
        return GetReccurentValue(StartCost, CostMultiplier, level);
    }

    public int GetHealthByLevel(int level)
    {
        return GetReccurentValue(StartHealth, HealthMultiplier, level);
    }

    public int GetAdditionalTowersAmountByLevel(int level)
    {
        return Mathf.Clamp(GetReccurentValue(StartAdditionalTowersAmount, AdditionalTowersAmountMultyplier, level), 0, MaxAdditionalTowersAmount);
    }

    public float GetTowerHealthFractionByLevel(int level)
    {
        return Mathf.Clamp01(GetReccurentValue(StartTowerHealthFraction, TowerHealthFractionMultyplier, level));
    }

    private int GetReccurentValue(int startValue, float multiplier, int stepsCount)
    {
        float result = startValue;

        for (int i = 0; i < stepsCount; i++)
        {
            result += i * multiplier;
        }

        return Mathf.RoundToInt(result);
    }

    private float GetReccurentValue(float startValue, float multiplier, int stepsCount)
    {
        float result = startValue;

        for (int i = 0; i < stepsCount; i++)
        {
            result += i * multiplier;
        }

        return result;
    }
}
