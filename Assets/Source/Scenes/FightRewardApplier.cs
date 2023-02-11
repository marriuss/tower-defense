using UnityEngine;

public class FightRewardApplier : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void ApplyReward(FightReward argument)
    {
        _player.Balance.AddMoney(argument.Money);
        _player.Deck.ApplyExperiencePoints(argument.CardExperiencePoints);
    }
}
