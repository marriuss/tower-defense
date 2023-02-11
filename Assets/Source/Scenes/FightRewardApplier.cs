using IJunior.TypedScenes;
using System.Collections.Generic;
using UnityEngine;

public class FightRewardApplier : MonoBehaviour, ISceneLoadHandler<FightReward>
{
    [SerializeField] private Player _player;

    public void OnSceneLoaded(FightReward argument)
    {
        if (argument == null)
            return;

        ApplyMoneyReward(argument.Money);
        ApplyExperienceReward(argument.CardExperiencePoints);
    }

    private void ApplyMoneyReward(int money)
    {
        _player.Balance.AddMoney(money);
    }

    private void ApplyExperienceReward(int cardExperiencePoints)
    {
        List<Card> cards = _player.Deck.Cards;

        foreach (Card card in cards)
        {
            if (card != null)
                card.AddExperiencePoints(cardExperiencePoints);
        }
    }
}
