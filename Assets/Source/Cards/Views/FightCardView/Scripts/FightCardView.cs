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
        SetInteractable(false);
    }

    public void Render(FightingCard card)
    {
        Card = card;

        if (card != null)
        {
            RenderUnitCard(Card);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetUsable(bool usable)
    {
        SetInteractable(usable);
    }

    protected override void OnButtonClick()
    {
        Clicked?.Invoke(this);
    }

    private void RenderUnitCard(FightingCard card)
    {
        _icon.sprite = card.Icon;
        _manaView.Render(card.ManaCost, card.Rarity);
    }
}
