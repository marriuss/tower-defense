using System;
using UnityEngine;
using UnityEngine.Events;

public class Card
{
    private const int MinLevel = 1;
    private const int MaxLevel = 10;
    private const int StartExperiencePointsRequired = 2;
    private const float RecurrentFormulaComponent = 0.15f;

    public bool IsUnlocked { get; private set; }
    public int ExperiencePoints { get; private set; }
    public int ExperiencePointsRequired { get; private set; }
    public int Level { get; private set; }
    public CardInfo CardInfo { get; private set; }
    public bool CanUpLevel => ExperiencePoints >= ExperiencePointsRequired && Level < MaxLevel;

    public event UnityAction ExperienceStatsChanged;

    public Card(CardInfo cardInfo)
    {
        CardInfo = cardInfo;
        Level = 1;
        ExperiencePoints = 0;
        ExperiencePointsRequired = StartExperiencePointsRequired;
        InvokeExperienceStatsChanges();
        IsUnlocked = false;
    }

    public Card(CardInfo cardInfo, int level, int experiencePoints)
    {
        CardInfo = cardInfo;
        Level = level;
        ExperiencePoints = experiencePoints;
        UpExperiencePointsRequiredToLevel(Level);
        InvokeExperienceStatsChanges();
        IsUnlocked = true;
    }

    public void Unlock()
    {
        IsUnlocked = true;
    }

    public void AddExperiencePoints(int experiencePoints)
    {
        if (experiencePoints < 0)
            throw new NegativeArgumentException();

        ExperiencePoints += experiencePoints;
    }

    public bool TryUpLevel()
    {
        bool canUpLevel = CanUpLevel;

        if (canUpLevel)
            UpLevel();

        return canUpLevel;
    }

    private void UpLevel()
    {
        ExperiencePoints -= ExperiencePointsRequired;
        Level++;
        UpExperiencePointsRequired();
    }

    private void UpExperiencePointsRequiredToLevel(int level)
    {
        ExperiencePointsRequired = StartExperiencePointsRequired;

        for (int i = MinLevel; i <= level; i++)
            UpExperiencePointsRequired();
    }

    private void UpExperiencePointsRequired()
    {
        ExperiencePointsRequired = CalculateExperiencePointsRequired();
    }

    private int CalculateExperiencePointsRequired() => (int)Math.Floor(ExperiencePointsRequired * RecurrentFormulaComponent + StartExperiencePointsRequired);

    private void InvokeExperienceStatsChanges()
    {
        ExperienceStatsChanged?.Invoke();
    }
}
