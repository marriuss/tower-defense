using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CardUpgrade : WorkButton
{
    public event UnityAction CardUpgraded;

    private Card _card;

    private void Start()
    {
        SetInteractable(_card.CanUpLevel);
    }

    public void Init(Card card)
    {
        _card = card;
    }

    protected override void OnButtonClick()
    {
        if (_card.TryUpLevel())
        {
            CardUpgraded?.Invoke();
        }

        SetInteractable(_card.CanUpLevel);
    }
}
