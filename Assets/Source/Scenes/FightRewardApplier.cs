using IJunior.TypedScenes;
using System.Collections.Generic;
using UnityEngine;

public class FightRewardApplier : MonoBehaviour, ISceneLoadHandler<FightReward>
{
    [SerializeField] private Player _player;

    public void OnSceneLoaded(FightReward argument)
    {
        ApplyMoneyReward(argument);
        ApplyExperienceReward(argument);
    }

    private void ApplyMoneyReward(FightReward reward)
    {
        _player.Balance.AddMoney(reward.Money);
    }

    private void ApplyExperienceReward(FightReward reward)
    {
        List<Card> cards = _player.Deck.Cards;

        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].AddExperiencePoints(reward.CardExperiencePoints);
        }
    }
}
