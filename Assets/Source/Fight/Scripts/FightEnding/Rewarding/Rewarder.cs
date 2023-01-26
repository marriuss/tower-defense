using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RewardAccounter))]
public class Rewarder : MonoBehaviour
{
    private const float ExperiencePointsLostMultiplier = 0.5f;

    private RewardAccounter _rewardAccounter;

    private void Awake()
    {
        _rewardAccounter = GetComponent<RewardAccounter>();
    }

    public FightReward GetReward(bool playerWon)
    {
        int money;
        int cardExperiencePoints = _rewardAccounter.TotalExperiencePoints;

        if (playerWon)
        {
            money = _rewardAccounter.Money;
        }
        else
        {
            money = 0;
            cardExperiencePoints = (int)(cardExperiencePoints * ExperiencePointsLostMultiplier);
        }

        return new FightReward(money, cardExperiencePoints);
    }
}
