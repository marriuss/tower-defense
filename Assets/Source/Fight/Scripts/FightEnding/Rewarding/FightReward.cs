using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightReward
{
    public int Money { get; private set; }
    public int CardExperiencePoints { get; private set; }

    public FightReward(int money, int experiencePoints)
    {
        Money = money;
        CardExperiencePoints = experiencePoints;
    }
}