using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FightCardView : WorkButton
{
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
        SetInteractable(true);
    }

    private void Disappear()
    {
        SetInteractable(false);
    }
}
