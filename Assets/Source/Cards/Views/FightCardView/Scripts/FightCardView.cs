using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class FightCardView : WorkButton
{
    [SerializeField] private Image _icon;
    [SerializeField] private FightCardManaView _manaView;

    public event UnityAction<FightCardView> Clicked;

    public FightingCard Card { get; private set; }

    private void Start()
    {
        Disappear();
    }

    public void Render(FightingCard card)
    {
        if (card != null)
        {
            Card = card;
            RenderUnitCard(Card);
        }
        else
        {
            Card = null;
            Disappear();
        }
    }

    protected override void OnButtonClick()
    {
        Clicked?.Invoke(this);
    }

    private void RenderUnitCard(FightingCard card)
    {
        _icon.sprite = card.Icon;
        _manaView.Render(card.ManaCost, card.Rarity);
        SetInteractable(true);
    }

    private void Disappear()
    {
        SetInteractable(false);
    }
}
