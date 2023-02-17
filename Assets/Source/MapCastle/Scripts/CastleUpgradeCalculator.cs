using UnityEngine;

public class CastleUpgradeCalculator
{
    private const int StartCost = 10;
    private const int StartHealth = 5;
    private const int StartAdditionalTowersAmount = 0;
    private const float StartTowerHealthFraction = 0.1f;

    private const float CostMultiplier = 5f;
    private const float HealthMultiplier = 5f;
    private const float AdditionalTowersAmountMultyplier = 0.0025f;
    private const float TowerHealthFractionMultyplier = 0.0002f;

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
        return Mathf.Clamp(
            GetReccurentValue(StartAdditionalTowersAmount, AdditionalTowersAmountMultyplier, level), 0, 5);
    }

    public float GetTowerHealthFractionByLevel(int level)
    {
        return Mathf.Clamp(
            GetReccurentValue(StartTowerHealthFraction, TowerHealthFractionMultyplier, level), 0, 1);
    }

    private int GetReccurentValue(int startValue, float multiplier, int stepsCount)
    {
        float result = 0;

        for (int i = 0; i < stepsCount; i++)
        {
            result += i * multiplier + startValue;
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
